import { Component } from '@angular/core';
import { smoothlyMenu } from '../../../app.helpers';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthorizeService } from '../../../../api-authorization/authorize.service';
declare var jQuery: any;

@Component({
  selector: 'topnavbar',
  templateUrl: 'topnavbar.template.html'
})
export class TopNavbarComponent {

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
