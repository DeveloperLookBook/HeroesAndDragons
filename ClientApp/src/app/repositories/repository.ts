import { HttpHeaders  } from '@angular/common/http';
import { TokenService } from './token.service';

export abstract class Repository {
    protected readonly hostUrl: string = 'https://localhost:44312/api';

    constructor(private token: TokenService) { }

    protected createHeaders(): HttpHeaders {
        return (this.token.isValid) ?
            new HttpHeaders().append('Content-Type' , 'application/json')
                             .append('Authorization', `Bearer ${this.token.value}` )
            :
            new HttpHeaders().append('Content-Type' , 'application/json');
    }
}
