import { Injectable } from '@angular/core';
import { BaseApiService } from './../../core/services/api/base-api.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import { AuthHttp } from 'angular2-jwt';
import { Http, RequestOptions, Headers, Response, Request, RequestMethod, URLSearchParams, QueryEncoder } from '@angular/http';
import { Appointment } from './../../models/appointment/Appointment';
import { plainToClass, plainToClassFromExist } from "class-transformer";
@Injectable()
export class AppointmentService extends BaseApiService<Appointment> {
  public resourceName: string = 'api/Appointment';
  constructor(protected http: Http) {
    super(http);
  }

  getByMonth(id: number): Observable<Appointment[]> {
    const url = `${this.basePath}${this.resourceName}/getbymonth?id=` + id;
    
    return this.http.get(url)
      .map(res => res.json())
      .map(res => plainToClassFromExist(this.entity, res as Object[]))
      .catch(this.handleError);
  }


  getMonths() {
    var month = new Array();
    month[0] = "Jan";
    month[1] = "Feb";
    month[2] = "Mar";
    month[3] = "Apr";
    month[4] = "May";
    month[5] = "Jun";
    month[6] = "Jul";
    month[7] = "Aug";
    month[8] = "Sep";
    month[9] = "Oct";
    month[10] = "Nov";
    month[11] = "Dec";
    return month;
  }
}
