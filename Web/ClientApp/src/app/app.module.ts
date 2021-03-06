import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from "@angular/router";
import { LocationStrategy, PathLocationStrategy } from '@angular/common';

import { ROUTES } from "./app.routes";
import { AppComponent } from './app.component';

// App views
import { AppviewsModule } from "./views/appviews/appviews.module";

// App modules/components
import { LayoutsModule } from "./components/common/layouts/layouts.module";
import { AuthorizeInterceptor } from '../api-authorization/authorize.interceptor';
import { ApiAuthorizationModule } from '../api-authorization/api-authorization.module';
import { CultivosModule } from './views/cultivos/cultivos.module';
//import { TareasModule } from './views/cultivos/cultivos.module';
import { UsuariosModule } from './usuarios/usuarios.module';
import { registerLocaleData } from '@angular/common';
import localeEsCo from '@angular/common/locales/es-CO';
registerLocaleData(localeEsCo);

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    LayoutsModule,
    CultivosModule,
    AppviewsModule,
    UsuariosModule,
    RouterModule.forRoot(ROUTES),
    ApiAuthorizationModule
  ],
  providers: [
    { provide: LocationStrategy, useClass: PathLocationStrategy },
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: LOCALE_ID, useValue: 'es-CO' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
