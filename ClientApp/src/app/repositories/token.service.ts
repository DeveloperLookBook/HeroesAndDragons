import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private readonly _changed     : Subject<boolean>;
  private readonly _key         : string;
  private readonly _localStorage: Storage;

  constructor() {
    this._changed      = new Subject<boolean>();
    this._key          = 'token';
    this._localStorage = window.localStorage;
  }


  private set(token: string): void {
    this._localStorage.setItem(this._key, token);
    this._changed.next(this.isValid);
  }

  private get(): string {
    return this._localStorage.getItem(this._key);
  }

  public remove(): void {
    this._localStorage.removeItem(this._key);
    this._changed.next(this.isValid);
  }


  get isValid(): boolean {
    return (this.get() ? true : false);
  }

  get onChanged(): Observable<boolean> {
    return this._changed.asObservable();
  }

  get value(): string {
    return this.isValid ? this.get() : '';
  }

  set value(token: string) {
    this.set(token);
  }
}
