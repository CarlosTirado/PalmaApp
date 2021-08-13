import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GestionCultivosComponent } from './gestion-cultivos/gestion-cultivos.component';
import { RegistroCultivoComponent } from './registro-cultivo/registro-cultivo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GestionLotesComponent } from './gestion-lotes/gestion-lotes.component';
import { GestionPalmasComponent } from './gestion-palmas/gestion-palmas.component';
import { GestionTareasComponent } from './gestion-tareas/gestion-tareas.component';

@NgModule({
  declarations: [
    GestionCultivosComponent,
    RegistroCultivoComponent,
    GestionLotesComponent,
    GestionPalmasComponent,
    GestionTareasComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class CultivosModule { }
