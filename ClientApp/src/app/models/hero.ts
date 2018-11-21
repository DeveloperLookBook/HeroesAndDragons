import { Character } from './character';
import { Weapon } from './weapon';

export class Hero extends Character {
    constructor(
        id: number,
        name: string,
        public readonly weapon: Weapon,
        created: Date) {
        super(id, name, created);
    }
}
