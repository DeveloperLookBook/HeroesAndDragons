import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { ICreateHitResponse } from '../repositories/icreate-hit-response';
import { CreateHitCommandPayload } from './create-hit-command-payload';
import { Command } from './command';

export class CreateHitCommand extends Command<RequestCommandHandlerService, Promise<ICreateHitResponse>> {

    constructor(
               handler: RequestCommandHandlerService,
        public payload: CreateHitCommandPayload) {
        super(handler);
    }

    execute(): Promise<ICreateHitResponse> {
        return this.handler.createHit(this);
    }
}
