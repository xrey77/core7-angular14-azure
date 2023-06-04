import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { LocateusComponent } from './locateus/locateus.component';
import { LoginComponent } from './auth/login/login.component';
import { RegistrationComponent } from './auth/registration/registration.component';
import { ProfileComponent } from './profile/profile.component';
import { ListComponent } from './products/list/list.component';
import { CatalogComponent } from './products/catalog/catalog.component';
import { SearchComponent } from './products/search/search.component';
import { MfaComponent } from './auth/mfa/mfa.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    AboutusComponent,
    LocateusComponent,
    LoginComponent,
    RegistrationComponent,
    ProfileComponent,
    ListComponent,
    CatalogComponent,
    SearchComponent,
    MfaComponent,
    HeaderComponent,
    FooterComponent        
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'aboutus', component: AboutusComponent },
      { path: 'locateus', component: LocateusComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'productlist', component: ListComponent },
      { path: 'productcatalog', component: CatalogComponent },
      { path: 'productsearch', component: SearchComponent },


    ])

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
