import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/app-config';
import { ApiResponse } from 'src/app/core/models/api/api-response';

import { TvMovie } from '../../models/tv-movie';

@Injectable()
export class TvMovieApiService {
    constructor(readonly http: HttpClient, readonly appConfig: AppConfig) {
    }

    getTvMovie(){
      return this.http.get<ApiResponse<TvMovie[]>>(`${this.baseUrl}`)
    }

    get baseUrl(): string {
        return `${this.appConfig.appSettings.apiEndpoints.endpoint}`;
    }
}