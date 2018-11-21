import { HitsFilterCode } from '../repositories/hits-filter-code.enum';
import { HitsOrderingCode } from '../repositories/hits-ordering-code.enum';
import { OrderCode } from '../repositories/order-code.enum';

export class GetHeroHitsCommandPayload {
    heroId    : number;
    filterBy  : HitsFilterCode;
    orderBy   : HitsOrderingCode;
    order     : OrderCode;
    pageNumber: number;
    pageSize  : number;
}
