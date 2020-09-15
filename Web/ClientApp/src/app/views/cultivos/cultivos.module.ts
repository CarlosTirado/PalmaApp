import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GestionCultivosComponent } from './gestion-cultivos/gestion-cultivos.component';
import { RegistroCultivoComponent } from './registro-cultivo/registro-cultivo.component';



@NgModule({
  declarations: [
    GestionCultivosComponent,
    RegistroCultivoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CultivosModule { }
