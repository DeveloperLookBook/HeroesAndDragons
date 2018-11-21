import { Injectable } from '@angular/core';
import { TokenService } from './token.service';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _isValid: boolean;
  private _changed: Subject<boolean>;

  constructor(private token: TokenService) {
    this._isValid = token.isValid;
    this._changed = new Subject<boolean>();

    token.onChanged.subscribe(value => {
      this._changed.next(this._isValid = value);
    });
  }

  get isValid(): boolean {
    return this._isValid;
  }

  get onChanged(): Observable<boolean> {
    return this._changed.asObservable();
  }

  dispose() {
    this.token.remove();
  }
}
