import { Injectable } from '@angular/core';
import { Repository } from './repository';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ISignupResponse } from './isignup-response';
import { IResponseError  } from './iresponse-error';
import { catchError      } from 'rxjs/operators';
import { throwError      } from 'rxjs';
import { HttpResponse } from 'selenium-webdriver/http';
import { TokenService } from './token.service';
import { ISigninResponse } from './isignin-response';
import { IModelsList } from './imodels-list';
import { Hero } from '../models/hero';
import { ICreateHitResponse } from './icreate-hit-response';
import { CreateHitCommandPayload } from '../commands/create-hit-command-payload';
import { GetHeroHitsCommandPayload } from '../commands/get-hero-hits-command-payload';
import { Hit } from '../models/hit';

@Injectable({
  providedIn: 'root'
})
export class HeroRepositoryService extends Repository {

  constructor(
    private http : HttpClient,
    token: TokenService) {
      super(token);
  }

  signupAsync(name: string) : Promise<ISignupResponse> {
    const headers = this.createHeaders();

    return this.http
      .post<ISignupResponse>(`${this.hostUrl}/account/signup`, { name }, { headers })
      .pipe(catchError((error: HttpErrorResponse) => {
        const status  : number = error.status;
        const message : any    = error.error.message ? error.error.message : error.error;
        const newError: IResponseError = { status, message };

        return throwError(newError);
      })).toPromise();
  }

  signinAsync(name: string) : Promise<ISigninResponse> {
    const headers = this.createHeaders();

    return this.http
      .post<ISigninResponse>(`${this.hostUrl}/account/signin`, { name }, { headers })
      .pipe(catchError((error: HttpErrorResponse) => {
          const status  : number = error.status;
          const message : any    = error.error.message ? error.error.message : error.error;
          const newError: IResponseError = { status, message };

          return throwError(newError);
      })).toPromise();
  }

  getHeroes(filterBy: string, orderBy: string, order: string, pageNumber: number = 1, pageSize: number = 15) {
    return this.http
      .get<IModelsList<Hero>>(
        `${this.hostUrl}/heroes/search-filter:${filterBy}/order-by:${orderBy}` +
        `/order:${order}/page-number:${pageNumber}/page-size:${pageSize}`,
        {headers: this.createHeaders()})
      .toPromise();
  }

  hitDragon(payload: CreateHitCommandPayload): Promise<ICreateHitResponse> {
    return this.http
      .post<ICreateHitResponse>(
        `${this.hostUrl}/heroes/hit-dragon`,
        { ...payload },
        { headers: this.createHeaders() })
      .toPromise();
  }

  getHeroHits(payload: GetHeroHitsCommandPayload): Promise<IModelsList<Hit>> {
    return this.http
      .post<IModelsList<Hit>>(
        `${this.hostUrl}/heroes/hits`,
        { ...payload },
        { headers: this.createHeaders() })
      .toPromise();
  }
}
