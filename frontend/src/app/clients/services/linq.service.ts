import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LinqService {
  constructor(private http: HttpClient) {}

  getData(currentPage: number, pageSize: number): Observable<any> {
    return this.http.get(`http://localhost:5000/client/linq?currentPage=${currentPage}&pageSize=${pageSize}`);
  }
}
