import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GestionCultivosComponent } from './gestion-cultivos/gestion-cultivos.component';
import { RegistroCultivoComponent } from './registro-cultivo/registro-cultivo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    GestionCultivosComponent,
    RegistroCultivoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class CultivosModule { }
