import { Character } from './character';

export class Dragon extends Character {
    constructor(
        id: number,
        name: string,
        public readonly health: number,
        created: Date
    ) {
        super(id, name, created);
    }
}
