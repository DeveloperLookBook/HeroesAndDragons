import { Hero } from '../models/hero';

export interface ISigninResponse {
    readonly token: string;
    readonly hero : Hero;
}
