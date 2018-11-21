import { Model } from './model';

export class Weapon extends Model {
    constructor(
        id: number,
        public readonly name: string,
        public readonly strength: number,
        created: Date
    ) {
        super(id, created);
    }
}
