import { Component, OnInit } from '@angular/core';
import { GetHeroHitsCommandPayload } from 'src/app/commands/get-hero-hits-command-payload';
import { HitsFilterCode } from 'src/app/repositories/hits-filter-code.enum';
import { HitsOrderingCode } from 'src/app/repositories/hits-ordering-code.enum';
import { OrderCode } from 'src/app/repositories/order-code.enum';
import { HeroService } from 'src/app/models/hero.service';
import { Hit } from 'src/app/models/hit';
import { IModelsList } from 'src/app/repositories/imodels-list';
import { CommandFactoryService } from 'src/app/commands/command-factory.service';

@Component({
  selector: 'app-hero-hits',
  templateUrl: './hero-hits.component.html',
  styleUrls: ['./hero-hits.component.css']
})
export class HeroHitsComponent implements OnInit {

  readonly searchSettings: GetHeroHitsCommandPayload;
  hits: IModelsList<Hit>;

  constructor(
    private commandFactory: CommandFactoryService,
    private hero          : HeroService
  ) {
    this.searchSettings = {
      heroId    : hero.instance.id,
      filterBy  : HitsFilterCode.All,
      orderBy   : HitsOrderingCode.ByCreated,
      order     : OrderCode.Descending,
      pageNumber: 1,
      pageSize  : 15,
    };
  }

  RunGetHeroHitsCommand(payload: GetHeroHitsCommandPayload) {
    this.commandFactory
    .createGetHeroHitsCommand(payload)
    .execute()
    .then   (value => this.hits = value);
  }

  LoadPages(pageNumber: number): void {
    this.searchSettings.pageNumber = pageNumber;
    this.RunGetHeroHitsCommand(this.searchSettings);
  }

  ngOnInit() {
    this.RunGetHeroHitsCommand(this.searchSettings);
  }

  toggleOrderCode(searchSettings: GetHeroHitsCommandPayload): void {
    this.searchSettings.order   = (this.searchSettings.order === OrderCode.Ascending) ?
    OrderCode.Descending : OrderCode.Ascending;
  }
  sortByTargetName() {
    this.searchSettings.orderBy = HitsOrderingCode.ByTargetName;
    this.toggleOrderCode      (this.searchSettings);
    this.RunGetHeroHitsCommand(this.searchSettings);
  }

  sortByWeaponName() {
    this.searchSettings.orderBy = HitsOrderingCode.ByWeaponName;
    this.toggleOrderCode      (this.searchSettings);
    this.RunGetHeroHitsCommand(this.searchSettings);
  }

  sortByWeaponStrength() {
    this.searchSettings.orderBy = HitsOrderingCode.ByWeaponStrength;
    this.toggleOrderCode      (this.searchSettings);
    this.RunGetHeroHitsCommand(this.searchSettings);
  }

  sortByStrength() {
    this.searchSettings.orderBy = HitsOrderingCode.ByStrength;
    this.toggleOrderCode      (this.searchSettings);
    this.RunGetHeroHitsCommand(this.searchSettings);
  }

  sortByCreated() {
    this.searchSettings.orderBy = HitsOrderingCode.ByCreated;
    this.toggleOrderCode      (this.searchSettings);
    this.RunGetHeroHitsCommand(this.searchSettings);
  }
}
