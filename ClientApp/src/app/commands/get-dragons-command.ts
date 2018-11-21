import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { IModelsList } from '../repositories/imodels-list';
import { Dragon } from '../models/dragon';
import { GetDragonsCommandPayload } from './get-dragons-command-payload';

export class GetDragonsCommand extends Command<RequestCommandHandlerService, Promise<IModelsList<Dragon>>> {
    constructor(
               handler: RequestCommandHandlerService,
        public payload: GetDragonsCommandPayload) {
        super(handler);
    }

    execute(): Promise<IModelsList<Dragon>> {
        return this.handler.getDragonsAsync(this);
    }
}
