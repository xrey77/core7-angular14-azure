using System.Text;
using core7_angular14_azure.Helpers;
using core7_angular14_azure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataDbContext>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "QATAR FOUNDATION", Description="Rest API Documentation", Version = "v1" });
        c.TagActionsBy(api =>
            {
                if (api.GroupName != null)
                {
                    return new[] { api.GroupName };
                }

                var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor != null)
                {
                    return new[] { controllerActionDescriptor.ControllerName };
                }

                throw new InvalidOperationException("Unable to determine tag for endpoint.");
            });
        c.DocInclusionPredicate((name, api) => true);        
    });
builder.Services.AddSpaStaticFiles(options => { options.RootPath = "clientapp/dist"; });
builder.Services.AddRazorPages();

// ============VALIDATE IF JWT TOKEN HAS BEEN GENERATED===================================
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Secret").Value!))
    };
});
//==========================================================================================

builder.Services.AddCors();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJWTTokenServices, JWTServiceManage>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "");
    });    
    app.UseHsts();    
}

// ==========VALIDATE IF END POINT IS AUTHORIZED================
app.UseStatusCodePages(async context =>
    {
        if (context.HttpContext.Request.Path.StartsWithSegments("/api"))
        {
            if (!context.HttpContext.Response.ContentLength.HasValue || context.HttpContext.Response.ContentLength == 0)
            {
                // Change ContentType as json serialize
                context.HttpContext.Response.ContentType = "text/json";
                await context.HttpContext.Response.WriteAsJsonAsync(new {message = "Unauthorized Access, Please Login using your account."});
            }
        }
        else
        {
            // Ignore redirect
            context.HttpContext.Response.Redirect($"/error?code={context.HttpContext.Response.StatusCode}");
        }
    });
//============================================================
// app.UseHttpsRedirection();
app.UseRouting();
app.UseSpaStaticFiles();
app.UseAuthorization();
app.UseCors( options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});


app.MapRazorPages();
app.UseSpa(spa =>
     {
         if (app.Environment.IsDevelopment())
             spa.Options.SourcePath = "clientapp/";
         else
             spa.Options.SourcePath = "dist";
     });
app.MapControllers();
app.Run();