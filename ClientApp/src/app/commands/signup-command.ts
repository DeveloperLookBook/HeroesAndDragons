import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';

export class SignupCommand extends Command<RequestCommandHandlerService, Promise<boolean>> {
    constructor(
        handler: RequestCommandHandlerService,
        public payload: { name: string }) {
        super(handler);
    }

    execute(): Promise<boolean> {
        return this.handler.signupAsync(this);
    }
}
