import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/app-config';
import { ApiResponse } from 'src/app/core/models/api/api-response';

import { TvShow } from '../../models/tv-show';

@Injectable({
  providedIn: 'root'
})
export class TvShowService {

  constructor(readonly http: HttpClient, readonly appConfig: AppConfig) { }

  getTvMovie(){
    return this.http.get<ApiResponse<TvShow[]>>(`${this.baseUrl}`)
  }

  get baseUrl(): string {
      return `${this.appConfig.appSettings.apiEndpoints.endpoint}`;
  }
}
