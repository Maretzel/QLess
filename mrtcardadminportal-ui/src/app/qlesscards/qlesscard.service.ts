import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Qlesscardtype } from '../models/api-models/qlesscardtype.model';

@Injectable({
  providedIn: 'root'
})
export class QlesscardService {

  private baseApiUrl = 'https://localhost:44376';

  constructor(private httpClient: HttpClient) { }

  getQlessCardType() : Observable<Qlesscardtype[]> {
    return this.httpClient.get<Qlesscardtype[]>(this.baseApiUrl + '/api/CardType');
  }
}
