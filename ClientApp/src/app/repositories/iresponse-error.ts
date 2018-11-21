export interface IResponseError {
    readonly status: number;
    readonly message: string | { [key: string]: string[] };
}
