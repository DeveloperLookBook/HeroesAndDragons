import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TokenService } from './token.service';
import { Repository } from './repository';
import { Dragon } from '../models/dragon';
import { IModelsList } from './imodels-list';
import { ICreateDragonResponse } from './icreate-dragon-response';

@Injectable({
  providedIn: 'root'
})
export class DragonRepositoryService extends Repository {

  constructor(
    private http : HttpClient,
            token: TokenService) {
      super(token);
  }

  createDragon(): Promise<ICreateDragonResponse> {
    const h = this.createHeaders();

    return this.http.post<ICreateDragonResponse>(
      `${this.hostUrl}/dragons/create`,
      null,
      { headers: this.createHeaders() })
      .toPromise();
  }

  getDragons(
    filterBy  : string,
    orderBy   : string,
    order     : string,
    pageNumber: number = 1,
    pageSize: number = 15): Promise<IModelsList<Dragon>> {

    return this.http.get<IModelsList<Dragon>>(
      `${this.hostUrl}/dragons/search-filter:${filterBy}/order-by:${orderBy}` +
        `/order:${order}/page-number:${pageNumber}/page-size:${pageSize}`,
      { headers: this.createHeaders() })
      .toPromise();
  }
}
