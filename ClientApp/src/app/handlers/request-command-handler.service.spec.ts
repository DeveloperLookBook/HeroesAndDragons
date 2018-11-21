import { TestBed, inject } from '@angular/core/testing';

import { RequestCommandHandlerService } from './request-command-handler.service';

describe('RequestCommandHandlerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RequestCommandHandlerService]
    });
  });

  it('should be created', inject([RequestCommandHandlerService], (service: RequestCommandHandlerService) => {
    expect(service).toBeTruthy();
  }));
});
