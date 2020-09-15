import { Component } from '@angular/core';
import {Router} from '@angular/router';
import 'jquery-slimscroll';
import { AuthorizeService } from '../../../../api-authorization/authorize.service';
import { TerceroService } from '../../../services/common/tercero.service';

declare var jQuery:any;

@Component({
  selector: 'navigation',
  templateUrl: 'navigation.template.html'
})

export class NavigationComponent {

  estaAutenticado: boolean;
  user: any;
  tercero: any;

  constructor(
    private router: Router,
    private authorizeService: AuthorizeService,
    private terceroService: TerceroService
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
      if (this.user.name !== null) {
        this.buscarTerceroPorCorreo(this.user.name);
      }
    });
  }

  buscarTerceroPorCorreo(correo: string) {
    this.terceroService.getTerceroPorCorreo(correo).subscribe(response => {
      this.tercero = response;
    });
  }

}
