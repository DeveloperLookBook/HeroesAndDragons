import { Model } from '../models/model';
import { IModelsListParams } from './imodels-list-params';

export interface IModelsList<TModel extends Model> {
    params: IModelsListParams;
    models: TModel[];
}
