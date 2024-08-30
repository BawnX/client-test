import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TableComponent, TableData } from './commons/components/table/table.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TableComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'frontend';
  currentTheme: string = 'light';

  ngOnInit() {
    this.detectColorScheme();
  }

  detectColorScheme() {
    if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
      this.currentTheme = 'dark';
    } else {
      this.currentTheme = 'light';
    }

    // Optional: Listen for changes in color scheme preference
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
      this.currentTheme = e.matches ? 'dark' : 'light';
    });
  }

  tableData: TableData[] = [
    { id: 1, name: 'John Doe', email: 'john@example.com', role: 'Admin' },
    { id: 2, name: 'Jane Smith', email: 'jane@example.com', role: 'User' },
    { id: 3, name: 'Bob Johnson', email: 'bob@example.com', role: 'User' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
    { id: 4, name: 'Alice Brown', email: 'alice@example.com', role: 'Manager' },
  ];

  columns: string[] = ['id', 'name', 'email', 'role'];
}
