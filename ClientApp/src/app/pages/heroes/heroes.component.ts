import { Component, OnInit } from '@angular/core';
import { IModelsList } from 'src/app/repositories/imodels-list';
import { Hero } from 'src/app/models/hero';
import { CommandFactoryService } from 'src/app/commands/command-factory.service';
import { GetHeroesCommandPayload } from 'src/app/commands/get-heroes-command-payload';
import { HeroesFilterCode } from 'src/app/repositories/heroes-filter-code.enum';
import { OrderCode } from 'src/app/repositories/order-code.enum';
import { HeroesOrderingCode } from 'src/app/repositories/heroes-ordering-code.enum';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css'],
})
export class HeroesComponent implements OnInit {
  readonly searchSettings: GetHeroesCommandPayload = {
    filterBy  : HeroesFilterCode.All,
    orderBy   : HeroesOrderingCode.ByCreated,
    order     : OrderCode.Descending,
    pageNumber: 1,
    pageSize  : 15,
  };
  heroes: IModelsList<Hero>;

  constructor(
    private commandFactory: CommandFactoryService
  ) { }

  RunGetHeroesCommand() {
    this.commandFactory
    .createGetHeroesCommand(this.searchSettings)
    .execute()
    .then   (value => this.heroes = value);
  }

  LoadPages(pageNumber: number): void {
    this.searchSettings.pageNumber = pageNumber;
    this.RunGetHeroesCommand();
  }

  ngOnInit() {
    this.RunGetHeroesCommand();
  }

  sortByName() {
    this.searchSettings.orderBy = HeroesOrderingCode.ByName;
    this.searchSettings.order = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetHeroesCommand();
  }

  sortByCreated() {
    this.searchSettings.orderBy = HeroesOrderingCode.ByCreated;
    this.searchSettings.order = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetHeroesCommand();
  }

  sortByWeaponName() {
    this.searchSettings.orderBy = HeroesOrderingCode.ByWeaponName;
    this.searchSettings.order = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetHeroesCommand();
  }

  sortByWeaponStrength() {
    console.log('sortByWeaponStrength');
    this.searchSettings.orderBy = HeroesOrderingCode.ByWeaponStrength;
    this.searchSettings.order   = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetHeroesCommand();
  }
}
