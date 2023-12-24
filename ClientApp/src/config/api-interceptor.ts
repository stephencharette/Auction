import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  constructor() {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Get the request url
    let requestUrl = req.url;
    // if the request URL have the string prefix,
    // then make the replace by the correct url
    if (requestUrl.indexOf('@api-x') !== -1) {
      requestUrl = requestUrl.replace('@api-x', environment.apiUrl);
    }
    // clone the http request
    req = req.clone({
      url: requestUrl,
    });
    // move to next HttpClient request life cycle
    return next.handle(req);
  }
}
