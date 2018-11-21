import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

import { AngularFontAwesomeModule } from 'angular-font-awesome';

import { SigninComponent } from './pages/signin/signin.component';
import { SignupComponent } from './pages/signup/signup.component';
import { HeroesComponent } from './pages/heroes/heroes.component';
import { DragonsComponent } from './pages/dragons/dragons.component';
import { DisabledForAuthUsersDirective } from './directives/disabled-for-auth-users.directive';
import { EnabledForAuthUsersDirective } from './directives/enabled-for-auth-users.directive';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { HeroHitsComponent } from './pages/hero-hits/hero-hits.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    AngularFontAwesomeModule
  ],
  providers: [],
  declarations: [
    AppComponent,
    SignupComponent,
    SigninComponent,
    HeroesComponent,
    DragonsComponent,
    EnabledForAuthUsersDirective,
    DisabledForAuthUsersDirective,
    PaginationComponent,
    HeroHitsComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
