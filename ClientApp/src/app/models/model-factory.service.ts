import { Injectable } from '@angular/core';
import { Weapon } from './weapon';
import { Hero } from './hero';
import { Dragon } from './dragon';
import { Hit } from './hit';

interface ModelCreator {
  hero   (id: number, name: string, weapon  : Weapon, created: Date): Hero;
  dragon (id: number, name: string, health  : number, created: Date): Dragon;
  weapon (id: number, name: string, strength: number, created: Date): Weapon;
  hit    (id: number, target: Hero | Dragon, source: Hero | Dragon, weapon: Weapon, created: Date): Hit;
}

@Injectable({
  providedIn: 'root'
})
export class ModelFactoryService {

  private modelCreator : ModelCreator = {
    hero(id: number, name: string, weapon: Weapon, created: Date): Hero {
      return new Hero(id, name, weapon, created);
    },
    dragon(id: number, name: string, health: number, created: Date): Dragon {
      return new Dragon(id, name, health, created);
    },
    weapon(id: number, name: string, strength: number, created: Date): Weapon {
      return new Weapon(id, name, strength, created);
    },
    hit(id: number, target: Hero | Dragon, source: Hero | Dragon, weapon: Weapon, created: Date) {
      return new Hit(id, target, source, weapon, created);
    }
  };

  constructor() { }

  create<TResult>(selector: (creator: ModelCreator) => TResult ) {
    return selector(this.modelCreator);
  }
}
