import { NgModule } from '@angular/core';
import { Routes, RouterModule, Route } from '@angular/router';
import { SigninComponent } from './pages/signin/signin.component';
import { SignupComponent } from './pages/signup/signup.component';
import { HeroesComponent } from './pages/heroes/heroes.component';
import { DragonsComponent } from './pages/dragons/dragons.component';
import { AuthGuard } from './guards/auth.guard';
import { NotAuthGuard } from './guards/not-auth.guard';
import { HeroHitsComponent } from './pages/hero-hits/hero-hits.component';

const routes: Routes = [
  { path: 'signup'   , component : SignupComponent  , canActivate: [NotAuthGuard] },
  { path: 'signin'   , component : SigninComponent  , canActivate: [NotAuthGuard] },
  { path: 'heroes'   , component : HeroesComponent  , canActivate: [AuthGuard   ] },
  { path: 'hero-hits', component : HeroHitsComponent, canActivate: [AuthGuard   ] },
  { path: 'dragons'  , component : DragonsComponent , canActivate: [AuthGuard   ] },

  { path: ''       , redirectTo: '/dragons', pathMatch: 'full'},
  { path: '**'     , component : SigninComponent         }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
