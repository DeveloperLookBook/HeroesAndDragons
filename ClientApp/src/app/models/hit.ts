import { Model } from './model';
import { Dragon } from './dragon';
import { Weapon } from './weapon';
import { Hero } from './hero';

export class Hit extends Model {
    constructor(
        id: number,
        public readonly target: Hero | Dragon,
        public readonly source: Hero | Dragon,
        public readonly weapon: Weapon,
        created: Date
    ) {
        super(id, created);
    }
}
