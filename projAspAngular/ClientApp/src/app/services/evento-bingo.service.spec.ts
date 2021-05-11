import { TestBed } from '@angular/core/testing';

import { EventoBingoService } from './evento-bingo.service';

describe('EventoBingoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EventoBingoService = TestBed.get(EventoBingoService);
    expect(service).toBeTruthy();
  });
});
