import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/app-config';

import { TvMovie } from '../../models/tv-movie';

@Injectable()
export class TvMovieApiService {
    constructor(readonly http: HttpClient, readonly appConfig: AppConfig) {
    }

    getTvMovie(){
      return this.http.get<TvMovie[]>(`${this.baseUrl}`)
    }

    get baseUrl(): string {
        return `${this.appConfig.appSettings.apiEndpoints.endpoint}`;
    }
}