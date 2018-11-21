import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { IModelsList } from '../repositories/imodels-list';
import { Hit } from '../models/hit';
import { GetHeroHitsCommandPayload } from './get-hero-hits-command-payload';

export class GetHeroHitsCommand extends Command<RequestCommandHandlerService, Promise<IModelsList<Hit>>> {
    constructor(
               handler: RequestCommandHandlerService,
        public payload: GetHeroHitsCommandPayload) {
        super(handler);
    }

    execute(): Promise<IModelsList<Hit>> {
        return this.handler.getHeroHits(this);
    }
}
