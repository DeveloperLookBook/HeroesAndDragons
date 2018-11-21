import { Model } from './model';

export abstract class Character extends Model {
    constructor(
        id: number,
        public readonly name: string,
        created: Date ) {
        super(id, created);
    }
}
