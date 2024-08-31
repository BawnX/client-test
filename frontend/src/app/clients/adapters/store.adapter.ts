import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { StoreService } from '../services/store.service';

@Injectable({
  providedIn: 'root'
})
export class StoreAdapter {
  constructor(private service: StoreService) {}

  adapter(currentPage: number, pageSize: number): Observable<any> {
    return this.service.getData(currentPage, pageSize).pipe(
      map(result => {
        const dataTable = result.data.$values.map((el: any, index:number) => {
          return {
            id: index + 1,
            fullName: el.fullName,
            country: el.countryName,
            phones: el.phoneNumber
          }
        }).flat()

        return {
          currentPage: result.currentPage,
          dataTable,
          columns: ['id', 'fullName', 'country', 'phones'],
          totalPages: result.totalPages
        }
      })
    )
  }
}
