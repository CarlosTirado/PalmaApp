import { Routes } from "@angular/router";

import { Dashboard1Component } from "./views/dashboards/dashboard1.component";
import { Dashboard2Component } from "./views/dashboards/dashboard2.component";
import { Dashboard3Component } from "./views/dashboards/dashboard3.component";
import { Dashboard4Component } from "./views/dashboards/dashboard4.component";
import { Dashboard41Component } from "./views/dashboards/dashboard41.component";
import { Dashboard5Component } from "./views/dashboards/dashboard5.component";

import { StarterViewComponent } from "./views/appviews/starterview.component";
import { LoginComponent } from "./views/appviews/login.component";

import { BlankLayoutComponent } from "./components/common/layouts/blankLayout.component";
import { BasicLayoutComponent } from "./components/common/layouts/basicLayout.component";
import { TopNavigationLayoutComponent } from "./components/common/layouts/topNavigationlayout.component";
import { AuthorizeGuard } from "../api-authorization/authorize.guard";

export const ROUTES: Routes = [
  // Main redirect
  { path: '', redirectTo: 'starterview', pathMatch: 'full' },

  // App views
  {
    path: 'dashboards', component: BasicLayoutComponent,
    children: [
      { path: 'dashboard1', component: Dashboard1Component, canActivate: [AuthorizeGuard] },
      { path: 'dashboard2', component: Dashboard2Component, canActivate: [AuthorizeGuard] },
      { path: 'dashboard3', component: Dashboard3Component, canActivate: [AuthorizeGuard] },
      { path: 'dashboard4', component: Dashboard4Component, canActivate: [AuthorizeGuard] },
      { path: 'dashboard5', component: Dashboard5Component, canActivate: [AuthorizeGuard] }
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
