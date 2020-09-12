import { Component } from '@angular/core';
import {Router, ActivatedRoute} from '@angular/router';
import { smoothlyMenu } from '../../../app.helpers';
import { AuthorizeService } from '../../../../api-authorization/authorize.service';
declare var jQuery:any;

@Component({
  selector: 'topnavigationnavbar',
  templateUrl: 'topnavigationnavbar.template.html'
})
export class TopNavigationNavbarComponent {

  estaAutenticado: boolean;

  constructor(
    private router: Router,
    private activeRoute: ActivatedRoute,
    private authorizeService: AuthorizeService
  ) {
    this.verificarSesion();
  }

  toggleNavigation(): void {
    jQuery("body").toggleClass("mini-navbar");
    smoothlyMenu();
  }

  goToLogout(): void {
    this.router.navigate(['/authentication/logout'], { state: { local: true } });
  }

  verificarSesion(): void {
    this.authorizeService.isAuthenticated().subscribe(response => {
      this.estaAutenticado = response;
    });
  }

}
