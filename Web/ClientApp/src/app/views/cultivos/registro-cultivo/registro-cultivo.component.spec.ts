import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroCultivoComponent } from './registro-cultivo.component';

describe('RegistroCultivoComponent', () => {
  let component: RegistroCultivoComponent;
  let fixture: ComponentFixture<RegistroCultivoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistroCultivoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistroCultivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
