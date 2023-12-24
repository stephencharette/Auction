import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

// Material UI imports
import { SearchItemsComponent } from './search-items/search-items.component';
import { ItemComponent } from './item/item.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { SearchComponent } from './search/search.component';
import { NewItemComponent } from './new-item/new-item.component';

import { environment } from 'src/environments/environment';
import { ApiInterceptor } from 'src/config/api-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SearchItemsComponent,
    ItemComponent,
    BreadcrumbComponent,
    SearchComponent,
    NewItemComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: SearchItemsComponent, pathMatch: 'full' },
      { path: 'items', component: ItemComponent, pathMatch: 'prefix' },
      { path: 'items/new', component: NewItemComponent, pathMatch: 'prefix' },
    ]),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiInterceptor,
      multi: true,
    },
    {
      provide: "BASE_API_URL", useValue: environment.apiUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
