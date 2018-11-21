export abstract class Command<THandler, TResult> {
    constructor(protected handler: THandler) { }

    abstract execute(): TResult;
}
