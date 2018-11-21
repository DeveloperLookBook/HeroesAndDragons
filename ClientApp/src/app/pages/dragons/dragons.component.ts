import { Component, OnInit } from '@angular/core';
import { GetDragonsCommandPayload } from 'src/app/commands/get-dragons-command-payload';
import { DragonsFilterCode } from 'src/app/repositories/dragons-filter-code.enum';
import { DragonsOrderingCode } from 'src/app/repositories/dragons-ordering-code.enum';
import { OrderCode } from 'src/app/repositories/order-code.enum';
import { Dragon } from 'src/app/models/dragon';
import { IModelsList } from 'src/app/repositories/imodels-list';
import { CommandFactoryService } from 'src/app/commands/command-factory.service';
import { ICreateDragonResponse } from 'src/app/repositories/icreate-dragon-response';
import { ICreateHitResponse } from 'src/app/repositories/icreate-hit-response';
import { CreateHitCommandPayload } from 'src/app/commands/create-hit-command-payload';
import { HeroService } from 'src/app/models/hero.service';

@Component({
  selector: 'app-dragons',
  templateUrl: './dragons.component.html',
  styleUrls: ['./dragons.component.css']
})
export class DragonsComponent implements OnInit {

  readonly searchSettings: GetDragonsCommandPayload = {
    filterBy  : DragonsFilterCode.All,
    orderBy   : DragonsOrderingCode.ByCreated,
    order     : OrderCode.Descending,
    pageNumber: 1,
    pageSize  : 15,
  };
  dragons: IModelsList<Dragon>;

  constructor(
    private commandFactory: CommandFactoryService,
    private hero          : HeroService
  ) { }

  RunGetDragonsCommand(payload: GetDragonsCommandPayload) {
    this.commandFactory
    .createGetDragonsCommand(payload)
    .execute()
    .then   (value => this.dragons = value);
  }

  RunCreateDragonCommand(): Promise<ICreateDragonResponse> {
    return this.commandFactory.createCreateDragonCommand().execute();
  }

  RunHitDragonCommand(payload: CreateHitCommandPayload): Promise<ICreateHitResponse> {
    return this.commandFactory.createCreateHitCommand(payload).execute();
  }

  createDragon() {
    this.RunCreateDragonCommand().then(value => this.RunGetDragonsCommand(this.searchSettings));
  }

  hitDragon(dragonId: number) {
    this.RunHitDragonCommand({
      sourceId: this.hero.instance.id,
      targetId: dragonId
    }).then(value => this.RunGetDragonsCommand(this.searchSettings));
  }

  LoadPages(pageNumber: number): void {
    this.searchSettings.pageNumber = pageNumber;
    this.RunGetDragonsCommand(this.searchSettings);
  }

  ngOnInit() {
    this.RunGetDragonsCommand(this.searchSettings);
  }

  sortByName() {
    this.searchSettings.orderBy = DragonsOrderingCode.ByName;
    this.searchSettings.order   = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetDragonsCommand(this.searchSettings);
  }

  sortByCreated() {
    this.searchSettings.orderBy = DragonsOrderingCode.ByCreated;
    this.searchSettings.order   = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetDragonsCommand(this.searchSettings);
  }

  sortByHealth() {
    this.searchSettings.orderBy = DragonsOrderingCode.ByHealth;
    this.searchSettings.order   = (this.searchSettings.order === OrderCode.Ascending) ?
      OrderCode.Descending : OrderCode.Ascending;
    this.RunGetDragonsCommand(this.searchSettings);
  }
}
