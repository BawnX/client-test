import { Component, Input, OnInit } from '@angular/core';

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
  @Input() columns: string[] = [];
  @Input() tableData: any[] = [];

  paginatedData: any[] = [];
  currentPage: number = 1;
  pageSize: number = 10; // Adjust as needed
  totalPages: number = this.tableData.length / this.pageSize;

  ngOnInit() {
    this.updatePaginatedData();
  }

  updatePaginatedData() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.paginatedData = this.tableData.slice(startIndex, endIndex);
    this.totalPages = Math.ceil(this.tableData.length / this.pageSize);
  }

  previousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updatePaginatedData();
    }
  }

  nextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.updatePaginatedData();
    }
  }
}
