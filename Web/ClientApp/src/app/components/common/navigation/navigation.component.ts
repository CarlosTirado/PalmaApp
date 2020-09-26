import { Component } from '@angular/core';
import {Router} from '@angular/router';
import 'jquery-slimscroll';
import { AuthorizeService } from '../../../../api-authorization/authorize.service';
import { TerceroService } from '../../../services/common/tercero.service';
import { AccountService } from '../../../services/common/account.service';

declare var jQuery:any;

@Component({
  selector: 'navigation',
  templateUrl: 'navigation.template.html'
})

export class NavigationComponent {

  estaAutenticado: boolean;
  user: any;
  tercero: any;
  roles: any;
  nombreRolGeneral: string;

  constructor(
    private router: Router,
    private authorizeService: AuthorizeService,
    private terceroService: TerceroService,
    private accountService: AccountService
  ) {
    console.log("Constructor");
    this.verificarSesion();
    this.buscarUsuario();
  }

  ngAfterViewInit() {
    jQuery('#side-menu').metisMenu();

    if (jQuery("body").hasClass('fixed-sidebar')) {
      jQuery('.sidebar-collapse').slimscroll({
        height: '100%'
      })
    }
  }

  activeRoute(routename: string): boolean{
    return this.router.url.indexOf(routename) > -1;
  }

  verificarSesion(): void {
    this.authorizeService.isAuthenticated().subscribe(response => {
      this.estaAutenticado = response;
    });
  }

  buscarUsuario(): void {
    this.authorizeService.getUser().subscribe(response => {
      this.user = response;
      if(!this.user) return;
      if (this.user.name !== null) {
        this.buscarTerceroPorCorreo(this.user.name);
        this.buscarRolesUsuarios(this.user.name);
      }
    });
  }

  buscarTerceroPorCorreo(correo: string) {
    this.terceroService.getTerceroPorCorreo(correo).subscribe(response => {
      this.tercero = response;
    });
  }
  buscarRolesUsuarios(username: string) {
    this.accountService.getUserRoles(username).subscribe(response => {
      this.roles = response;

      if (this.roles.filter(t => t.name === "Dueño").length > 0) this.nombreRolGeneral = "Dueño"; 
      if (this.roles.filter(t => t.name === "Administrador").length > 0) this.nombreRolGeneral = "Administrador"; 
      if (this.roles.filter(t => t.name === "Operario").length > 0) this.nombreRolGeneral = "Operario";

    });
  }

  goToLogout(): void {
    this.router.navigate(['/authentication/logout'], { state: { local: true } });
  }

}
