import { Directive, ViewContainerRef, TemplateRef, OnInit } from '@angular/core';
import { AuthService } from '../repositories/auth.service';

@Directive({
  // tslint:disable-next-line:directive-selector
  selector: '[disabled-for-auth-users]'
})
export class DisabledForAuthUsersDirective implements OnInit {

  constructor(
    private auth     : AuthService,
    private container: ViewContainerRef,
    private template : TemplateRef<any>) {
    auth.onChanged.subscribe(value => {
      this.toggleViewVisibility(value);
    });
  }

  ngOnInit(): void {
    this.toggleViewVisibility(this.auth.isValid);
  }

  toggleViewVisibility(isUserAuth: boolean) {
    if (isUserAuth) {
      this.container.clear();
    } else {
      this.container.createEmbeddedView(this.template);
    }
  }
}
