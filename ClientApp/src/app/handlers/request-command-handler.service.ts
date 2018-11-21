import { Injectable } from '@angular/core';
import { TokenService } from '../repositories/token.service';
import { SignupCommand } from '../commands/signup-command';
import { HeroRepositoryService } from '../repositories/hero-repository.service';
import { SignoutCommand } from '../commands/signout-command';
import { SigninCommand } from '../commands/signin-command';
import { Hero } from '../models/hero';
import { HeroService } from '../models/hero.service';
import { Router } from '@angular/router';
import { GetHeroesCommand } from '../commands/get-heroes-command';
import { IModelsList } from '../repositories/imodels-list';
import { Dragon } from '../models/dragon';
import { GetDragonsCommand } from '../commands/get-dragons-command';
import { DragonRepositoryService } from '../repositories/dragon-repository.service';
import { CreateDragonCommand } from '../commands/create-dragon-command';
import { ICreateDragonResponse } from '../repositories/icreate-dragon-response';
import { CreateHitCommand } from '../commands/create-hit-command';
import { ICreateHitResponse } from '../repositories/icreate-hit-response';
import { GetHeroHitsCommand } from '../commands/get-hero-hits-command';
import { Hit } from '../models/hit';

@Injectable({
  providedIn: 'root'
})
export class RequestCommandHandlerService {

  constructor(
    private heroRepository  : HeroRepositoryService,
    private dragonRepository: DragonRepositoryService,
    private token           : TokenService,
    private hero            : HeroService,
    private router          : Router) {
  }

    signupAsync(command: SignupCommand): Promise<boolean> {
        return new Promise((resolve, reject) => {
            this.heroRepository
                .signupAsync(command.payload.name)
                .then(
                    response => {
                        this.token.value   = response.token;
                        this.hero.instance = response.hero;
                        this.router.navigate(['/dragons']);

                        return resolve(true);
                    },
                    error => {
                        return reject(error);
                    }
                );
        });
    }

    signoutAsync(command: SignoutCommand): Promise<void> {
        return new Promise((resolve, reject) => {
            this.token.remove();
            this.hero .remove();
            this.router.navigate(['/signin']);
            this.token.isValid ? reject() : resolve();
        });
    }

    signinAsync(command: SigninCommand): Promise<Hero> {
        return new Promise((resolve, reject) => {
            this.heroRepository
                .signinAsync(command.payload.name)
                .then(
                    response => {
                        this.token.value    = response.token;
                        this.hero .instance = response.hero ;
                        this.router.navigate(['/dragons']);

                        return resolve({ ...response.hero });
                    },
                    error => {
                        return reject(error);
                    }
                );
        });
    }

    getHeroesAsync(command: GetHeroesCommand): Promise<IModelsList<Hero>> {
        const payload = command.payload;

        return this.heroRepository.getHeroes(
                payload.filterBy,
                payload.orderBy,
                payload.order,
                payload.pageNumber,
                payload.pageSize);
    }

    getDragonsAsync(command: GetDragonsCommand): Promise<IModelsList<Dragon>> {
        const payload = command.payload;

        return this.dragonRepository.getDragons(
                payload.filterBy,
                payload.orderBy,
                payload.order,
                payload.pageNumber,
                payload.pageSize);
    }

    createDragon(command: CreateDragonCommand): Promise<ICreateDragonResponse> {
        return this.dragonRepository.createDragon();
    }

    createHit(command: CreateHitCommand): Promise<ICreateHitResponse> {
        return this.heroRepository.hitDragon(command.payload);
    }

    getHeroHits(command: GetHeroHitsCommand): Promise<IModelsList<Hit>> {
        return this.heroRepository.getHeroHits(command.payload);
    }
}
