import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseCommandResponse } from '../models/api-models/basecommandresponse.model';
import { LoadParameter } from '../models/api-models/loadparameter.model';

@Injectable({
  providedIn: 'root'
})
export class LoadCardService {

  private baseApiUrl = 'https://localhost:44376';

  constructor(private httpClient: HttpClient) { }

  loadCard(loadParameter: LoadParameter) : Observable<BaseCommandResponse> {
    return this.httpClient.put<BaseCommandResponse>(this.baseApiUrl + '/api/Cards',  loadParameter);
  }
}
