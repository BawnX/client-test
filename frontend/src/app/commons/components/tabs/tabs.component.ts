import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { TableComponent } from '../table/table.component';

export interface TabData {
  title: string,
  data?: any,
  type: "table"
}

@Component({
  standalone:true,
  selector: 'tabs-component',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.css'],
  imports: [CommonModule, TableComponent]
})
export class TabsComponent implements OnInit {
  @Input() tabs: TabData[] = [];
  activeTab = 0;

  setActiveTab(index: number) {
    this.activeTab = index;
  }


  ngOnInit() {
    this.initTabs();
  }

  initTabs() {
    const tabButtons = document.querySelectorAll('.tab-button');
    const tabPanes = document.querySelectorAll('.tab-pane');

    tabButtons.forEach(button => {
      button.addEventListener('click', function(this: HTMLElement) {
        const tabId = this.getAttribute('data-tab');

        if(!tabId){
          return
        }

        tabButtons.forEach(btn => btn.classList.remove('active'));
        tabPanes.forEach(pane => pane.classList.remove('active'));

        this.classList.add('active');
        document.getElementById(tabId)?.classList.add('active');
      });
    });
  }
}
