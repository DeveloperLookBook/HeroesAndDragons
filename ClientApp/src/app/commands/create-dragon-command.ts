import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { ICreateDragonResponse } from '../repositories/icreate-dragon-response';

export class CreateDragonCommand extends Command<RequestCommandHandlerService, Promise<ICreateDragonResponse>> {

    constructor(handler: RequestCommandHandlerService) {
        super(handler);
    }

    execute(): Promise<ICreateDragonResponse> {
        return this.handler.createDragon(this);
    }
}
