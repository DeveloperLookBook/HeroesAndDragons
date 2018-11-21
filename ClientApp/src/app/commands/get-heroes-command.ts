import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { GetHeroesCommandPayload } from './get-heroes-command-payload';
import { Hero } from '../models/hero';
import { IModelsList } from '../repositories/imodels-list';

export class GetHeroesCommand extends Command<RequestCommandHandlerService, Promise<IModelsList<Hero>>> {
    constructor(
               handler: RequestCommandHandlerService,
        public payload: GetHeroesCommandPayload) {
        super(handler);
    }

    execute(): Promise<IModelsList<Hero>> {
        return this.handler.getHeroesAsync(this);
    }
}
