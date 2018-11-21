import { Injectable } from '@angular/core';
import { Hero } from './hero';
import { _localeFactory } from '@angular/core/src/application_module';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  private readonly _changed     : Subject<Hero>;
  private readonly _key         : string;
  private readonly _localStorage: Storage;

  constructor() {
    this._changed      = new Subject<Hero | null>();
    this._key          = 'hero';
    this._localStorage = window.localStorage;
  }

  private get(): Hero {
    return JSON.parse(this._localStorage.getItem(this._key)) as Hero;
  }

  private set(hero: Hero): void {
    this._localStorage.setItem(this._key, JSON.stringify(hero));
    this._changed.next({...hero});
  }

  public  remove(): void {
    this._localStorage.removeItem(this._key);
    this._changed.next(null);
  }

  get onChanged(): Observable<Hero | null> {
    return this._changed.asObservable();
  }

  get instance() {
    return this.get();
  }

  set instance(hero: Hero) {
    this.set(hero);
  }
}
