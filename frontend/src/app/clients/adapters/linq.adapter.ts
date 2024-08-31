import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { LinqService } from '../services/linq.service';

@Injectable({
  providedIn: 'root'
})
export class LinqAdapter {
  constructor(private service: LinqService) {}

  adapter(currentPage: number, pageSize: number): Observable<any> {
    return this.service.getData(currentPage, pageSize).pipe(
      map(result => {
        const dataTable = result.data.$values.map((el: any, index:number) => {
          const phone = el.phones.$values.map((p:any) => {
            return this.convertPhone(p)
          }).join('; ')


          return {
            id: index + 1,
            fullName: el.fullName,
            country: el.country,
            phones: phone
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

  convertPhone(str: string){
    const intl = str.slice(0,3);
    const f1 = str.slice(3,7);
    const f2 = str.slice(7,11);
    return `${intl} ${f1} ${f2}`;
  }
}
