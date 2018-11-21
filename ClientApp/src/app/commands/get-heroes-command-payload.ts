export class GetHeroesCommandPayload {
    constructor(
    public filterBy  : string,
    public orderBy   : string,
    public order     : string,
    public pageNumber = 1,
    public pageSize   = 15,
    ) { }
}
