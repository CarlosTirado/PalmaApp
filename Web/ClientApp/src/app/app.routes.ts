import { Routes } from "@angular/router";

import { StarterViewComponent } from "./views/appviews/starterview.component";
import { LoginComponent } from "./views/appviews/login.component";

import { BlankLayoutComponent } from "./components/common/layouts/blankLayout.component";
import { BasicLayoutComponent } from "./components/common/layouts/basicLayout.component";
import { AuthorizeGuard } from "../api-authorization/authorize.guard";
import { GestionCultivosComponent } from "./views/cultivos/gestion-cultivos/gestion-cultivos.component";
import { GestionUsuariosComponent } from "./usuarios/gestion-usuarios/gestion-usuarios.component";
import { GestionLotesComponent } from "./views/cultivos/gestion-lotes/gestion-lotes.component";
import { GestionPalmasComponent } from "./views/cultivos/gestion-palmas/gestion-palmas.component";
import { GestionTareasComponent } from "./views/cultivos/gestion-tareas/gestion-tareas.component";
import { AlertasComponent } from "./views/cultivos/alertas/alertas.component";

export const ROUTES: Routes = [
  // Main redirect
  { path: '', redirectTo: 'starterview', pathMatch: 'full' },

  // App views
  {
    path: 'cultivos', component: BasicLayoutComponent,
    children: [
      { path: 'gestion', component: GestionCultivosComponent, canActivate: [AuthorizeGuard] },
      { path: ':cultivoId/Lotes', component: GestionLotesComponent, canActivate: [AuthorizeGuard] },
      { path: ':cultivoId/Lotes/:loteId/Palmas', component: GestionPalmasComponent, canActivate: [AuthorizeGuard] },
    ]
  },
  // Ruta para la gestion de usuario
  {
    path: 'usuarios', component: BasicLayoutComponent,
    children: [
      { path: 'gestion', component: GestionUsuariosComponent, canActivate: [AuthorizeGuard] },
    ]
  },
  // Ruta para la gestion de tareas
  {
    path: 'tareas', component: BasicLayoutComponent,
    children: [
      { path: 'programar', component: GestionTareasComponent, canActivate: [AuthorizeGuard] },
      { path: 'crear', component: GestionTareasComponent, canActivate: [AuthorizeGuard] },
    ]
  },
  {
    path: 'alertas', component: BasicLayoutComponent,
    children: [
      { path: 'gestion', component: AlertasComponent, canActivate: [AuthorizeGuard] },
    ]
  },
  {
    path: '', component: BasicLayoutComponent,
    children: [
      { path: 'starterview', component: StarterViewComponent }
    ]
  },
  {
    path: '', component: BlankLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent },
    ]
  },

  // Handle all other routes
  { path: '**', redirectTo: 'starterview' }
];
