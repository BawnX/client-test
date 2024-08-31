import { TestBed } from '@angular/core/testing';
import { LinqAdapter } from './linq.adapter';
import { HttpTestingController } from '@angular/common/http/testing';
import { LinqService } from '../services/linq.service';
import { StoreAdapter } from './store.adapter';

describe('StoreAdapter', () => {
  let linqAdapter: LinqAdapter;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpTestingController],
      providers: [StoreAdapter, LinqAdapter, LinqService]
    });
    linqAdapter = TestBed.inject(LinqAdapter);
  });

  describe('convertTelephone', () => {
    it('should convert a telephone number to the correct format', () => {
      const inputTelephone = '+56933445566';
      const expectedOutput = '+569 3344 5566';

      const result = linqAdapter.convertPhone(inputTelephone);

      expect(result).toBe(expectedOutput);
    });

    it('should return an empty string for invalid input', () => {
      const invalidInput = 'abc123';

      expect(linqAdapter.convertPhone(invalidInput)).toBe('');
    });

    it('should handle telephone numbers with country codes', () => {
      const ukNumber = '+441234567';
      const expectedUkOutput = '+44 1234 5678';

      expect(linqAdapter.convertPhone(ukNumber)).toBe(expectedUkOutput);
    });
  });
});
