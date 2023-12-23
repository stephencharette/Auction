import { Component } from '@angular/core';

@Component({
  selector: 'app-search-items',
  templateUrl: './search-items.component.html',
  styleUrls: ['./search-items.component.css']
})
export class SearchItemsComponent {
  searchResults: ItemRm[] = [
    {
      title: '2017 16" Macbook Pro',
      description: "256 GB",
      brand: { name: "Apple" }
    },
    {
      title: '2015 15" Macbook Pro',
      description: "512 GB",
      brand: { name: "Apple" }
    }
  ]
}

export interface ItemRm {
  title: string;
  description: string;
  brand: Brand;
}

export interface Brand {
  name: string;
}
