import { Hero } from '../models/hero';

export interface ISignupResponse {
    readonly token: string;
    readonly hero : Hero;
}
