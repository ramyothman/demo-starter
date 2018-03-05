import { Injectable } from '@angular/core';
import { BaseApiService } from './../../core/services/api/base-api.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import { AuthHttp } from 'angular2-jwt';
import { Http, RequestOptions, Headers, Response, Request, RequestMethod, URLSearchParams, QueryEncoder } from '@angular/http';
import { Orders } from './../../models/checkout/Orders';
import { OrderItem } from './../../models/checkout/OrderItem';
import { plainToClass, plainToClassFromExist } from "class-transformer";
@Injectable()
export class OrdersService extends BaseApiService<Orders> {
  public resourceName: string = 'api/Orders';
  constructor(protected http: Http) {
    super(http);
  }

  getOrder(id: string): Observable<Orders> {
    const url = `${this.basePath}${this.resourceName}/GetByID?id=${id}`;
    
    return this.http.get(url)
      .map(res => res.json())
      .map(res => plainToClassFromExist(this.entity, res as Object[]))
      .catch(this.handleError);
  }
}
