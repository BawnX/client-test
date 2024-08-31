import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

export interface TableData {
  id: number;
  name: string;
  email: string;
  role: string;
}

@Component({
  standalone: true,
  selector: 'table-component',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  @Input() data: (currentPage: number, pageSize: number) => any = ()=>{};

  columns: string[] = [];
  tableData: any[] = [];
  currentPage: number = 1;
  pageSize: number = 10; // Adjust as needed
  totalPages: number = 0;

  ngOnInit() {
    this.loadData()
  }

  loadData(){
    this.data(this.currentPage, this.pageSize)
    .subscribe({
      next: (result: any) => {
        if(result){
          this.tableData = result.dataTable
          this.columns = result.columns
          this.currentPage = result.currentPage
          this.totalPages = result.totalPages
        }
      },
      error: (error: any) => console.log(error)
    })
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadData()
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.loadData()
    }
  }
}
