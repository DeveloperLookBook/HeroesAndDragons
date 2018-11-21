import { Injectable } from '@angular/core';
import { RequestCommandHandlerService } from '../handlers/request-command-handler.service';
import { SigninCommand } from './signin-command';
import { SignupCommand } from './signup-command';
import { SignoutCommand } from './signout-command';
import { GetHeroesCommand } from './get-heroes-command';
import { GetHeroesCommandPayload } from './get-heroes-command-payload';
import { GetDragonsCommandPayload } from './get-dragons-command-payload';
import { GetDragonsCommand } from './get-dragons-command';
import { CreateDragonCommand } from './create-dragon-command';
import { CreateHitCommand } from './create-hit-command';
import { CreateHitCommandPayload } from './create-hit-command-payload';
import { GetHeroHitsCommand } from './get-hero-hits-command';
import { GetHeroHitsCommandPayload } from './get-hero-hits-command-payload';

@Injectable({
  providedIn: 'root'
})
export class CommandFactoryService {
  private readonly handler: RequestCommandHandlerService;
  constructor(
    handler: RequestCommandHandlerService
  ) {
    this.handler = handler;
  }

  createSigninCommand(payload: { name: string }): SigninCommand {
    return new SigninCommand(this.handler, payload);
  }
  createSignupCommand(payload: { name: string }): SignupCommand {
    return new SignupCommand(this.handler, payload);
  }
  createSignoutCommand(): SignoutCommand {
    return new SignoutCommand(this.handler);
  }
  createGetHeroesCommand(payload: GetHeroesCommandPayload): GetHeroesCommand {
    return new GetHeroesCommand(this.handler, payload);
  }
  createGetDragonsCommand(payload: GetDragonsCommandPayload): GetDragonsCommand {
    return new GetDragonsCommand(this.handler, payload);
  }
  createCreateDragonCommand(): CreateDragonCommand {
    return new CreateDragonCommand(this.handler);
  }

  createCreateHitCommand(payload: CreateHitCommandPayload): CreateHitCommand {
    return new CreateHitCommand(this.handler, payload);
  }

  createGetHeroHitsCommand(payload: GetHeroHitsCommandPayload): GetHeroHitsCommand {
    return new GetHeroHitsCommand(this.handler, payload);
  }
}
