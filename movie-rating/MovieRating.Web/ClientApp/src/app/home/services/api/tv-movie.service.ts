import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/app-config';
import { ApiResponse } from 'src/app/core/models/api/api-response';

import { TvMovie } from '../../models/tv-movie';

@Injectable()
export class TvMovieApiService {
    numberOfMoviesLoaded: number = 10;
    constructor(readonly http: HttpClient, readonly appConfig: AppConfig) {
    }

    getTvMovie(){
      return this.http.get<TvMovie[]>(`${this.baseUrl}/movie?min=1&max=${this.numberOfMoviesLoaded}`);
    }

    loadMoreTvMovies(){
      return this.http.get<TvMovie[]>(`${this.baseUrl}/movie?min=${this.numberOfMoviesLoaded + 1}&max=${this.numberOfMoviesLoaded+=10}`);
    }

    get baseUrl(): string {
        return `${this.appConfig.appSettings.apiEndpoints.endpoint}`;
    }
}