import { Routes } from "@angular/router";

import { StarterViewComponent } from "./views/appviews/starterview.component";
import { LoginComponent } from "./views/appviews/login.component";

import { BlankLayoutComponent } from "./components/common/layouts/blankLayout.component";
import { BasicLayoutComponent } from "./components/common/layouts/basicLayout.component";
import { AuthorizeGuard } from "../api-authorization/authorize.guard";
import { GestionCultivosComponent } from "./views/cultivos/gestion-cultivos/gestion-cultivos.component";
import { RegistroCultivoComponent } from "./views/cultivos/registro-cultivo/registro-cultivo.component";
import { GestionUsuariosComponent } from "./usuarios/gestion-usuarios/gestion-usuarios.component";

export const ROUTES: Routes = [
  // Main redirect
  { path: '', redirectTo: 'starterview', pathMatch: 'full' },

  // App views
  {
    path: 'cultivos', component: BasicLayoutComponent,
    children: [
      { path: 'gestion', component: GestionCultivosComponent, canActivate: [AuthorizeGuard] },
      { path: 'registro', component: RegistroCultivoComponent, canActivate: [AuthorizeGuard] },
    ]
  },
  // Ruta para la gestion de usuario
  {
    path: 'usuarios', component: BasicLayoutComponent,
    children: [
      { path: 'gestion', component: GestionUsuariosComponent, canActivate: [AuthorizeGuard] },
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
