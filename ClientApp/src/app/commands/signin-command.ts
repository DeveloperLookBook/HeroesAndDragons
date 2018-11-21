import { Command } from './command';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { Hero } from '../models/hero';

export class SigninCommand extends Command<RequestCommandHandlerService, Promise<Hero>> {
    constructor(
        handler: RequestCommandHandlerService,
        public payload: { name: string }) {
        super(handler);
    }

    execute(): Promise<Hero> {
        return this.handler.signinAsync(this);
    }
}
