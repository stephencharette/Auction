import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from 'src/models/item';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-search-items',
  templateUrl: './search-items.component.html',
  styleUrls: ['./search-items.component.css']
})
export class SearchItemsComponent implements OnInit {
  constructor(private http: HttpClient) {}
  searchResults: Item[] = []
  getDataFromServer() {
    this.http.get<any>('@api-x/item').subscribe(
      (data) => {
        console.log("asdfasdf");
        this.searchResults = data;
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }

  ngOnInit() {
    this.getDataFromServer();
  }
}
