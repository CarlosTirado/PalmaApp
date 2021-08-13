import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionCultivosComponent } from './gestion-cultivos.component';

describe('GestionCultivosComponent', () => {
  let component: GestionCultivosComponent;
  let fixture: ComponentFixture<GestionCultivosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionCultivosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionCultivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
