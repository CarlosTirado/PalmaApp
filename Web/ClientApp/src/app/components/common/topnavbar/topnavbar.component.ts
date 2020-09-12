import { Component } from '@angular/core';
import { smoothlyMenu } from '../../../app.helpers';
import { Router, ActivatedRoute } from '@angular/router';
declare var jQuery:any;

@Component({
  selector: 'topnavbar',
  templateUrl: 'topnavbar.template.html'
})
export class TopNavbarComponent {

    constructor(
        private router: Router,
        private activeRoute: ActivatedRoute) { }

  toggleNavigation(): void {
    jQuery("body").toggleClass("mini-navbar");
    smoothlyMenu();
    }

    goToLogout(): void {
        this.router.navigate(['/authentication/logout'], { state: { local: true } });
    }

}
