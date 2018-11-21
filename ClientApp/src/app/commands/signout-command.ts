import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';

export class SignoutCommand extends Command<RequestCommandHandlerService, Promise<void>> {
    constructor(
        handler: RequestCommandHandlerService) {
        super(handler);
    }

    execute(): Promise<void> {
        return this.handler.signoutAsync(this);
    }
}
