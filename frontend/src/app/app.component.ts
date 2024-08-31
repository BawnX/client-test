import { Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TabData, TabsComponent } from './commons/components/tabs/tabs.component';
import { LinqAdapter } from './clients/adapters/linq.adapter';
import { StoreAdapter } from './clients/adapters/store.adapter';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TabsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
  linqAdapter: LinqAdapter;
  storeAdapter: StoreAdapter;

  constructor(linqAdapter: LinqAdapter, storeAdapter: StoreAdapter){
    this.linqAdapter = linqAdapter
    this.storeAdapter = storeAdapter
  }

  tabsData: TabData[] = [
    {
      title: 'Store Prodecure',
      type: 'table',
      data: (currentPage: number, pageSize: number) => this.storeAdapter.adapter(currentPage, pageSize)
    },
    {
      title: 'Linq',
      type: 'table',
      data: (currentPage: number, pageSize: number) => this.linqAdapter.adapter(currentPage, pageSize)
    }
  ]
}
