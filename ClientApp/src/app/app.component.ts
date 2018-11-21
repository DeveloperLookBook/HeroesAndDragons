import { Component, OnInit } from '@angular/core';
import { CommandFactoryService } from './commands/command-factory.service';
import { SignoutCommand } from './commands/signout-command';
import { Hero } from './models/hero';
import { HeroService } from './models/hero.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  hero: Hero;

  constructor(
    private commandFactory: CommandFactoryService,
    private heroService   : HeroService) { }

  signout() {
     this.commandFactory
         .createSignoutCommand()
         .execute();
  }

  ngOnInit(): void {
    this.hero = this.heroService.instance;
    this.heroService
        .onChanged
        .subscribe(h => {
          return this.hero = h;
        });
  }
}
