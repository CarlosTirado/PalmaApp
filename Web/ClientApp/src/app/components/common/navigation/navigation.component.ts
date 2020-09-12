import { Component } from '@angular/core';
import {Router} from '@angular/router';
import 'jquery-slimscroll';
import { AuthorizeService } from '../../../../api-authorization/authorize.service';

declare var jQuery:any;

@Component({
  selector: 'navigation',
  templateUrl: 'navigation.template.html'
})

export class NavigationComponent {

  estaAutenticado: boolean;

  constructor(
    private router: Router,
    private authorizeService: AuthorizeService
  ) {
    this.verificarSesion();
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

    this.authorizeService.getUser().subscribe(response => {
      alert(JSON.stringify(response));
    });
  }

}
