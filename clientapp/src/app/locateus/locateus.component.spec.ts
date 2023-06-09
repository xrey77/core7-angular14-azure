import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocateusComponent } from './locateus.component';

describe('LocateusComponent', () => {
  let component: LocateusComponent;
  let fixture: ComponentFixture<LocateusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LocateusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocateusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
