import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/app-config';
import { TvShow } from '../../models/tv-show';

@Injectable({
  providedIn: 'root'
})
export class TvShowApiService {
  numberOfShowsLoaded: number = 10;

  constructor(readonly http: HttpClient, readonly appConfig: AppConfig) { }

  getTvShow(){
    return this.http.get<TvShow[]>(`${this.baseUrl}/show?min=1&max=${this.numberOfShowsLoaded}`)
  }

  loadMoreTvShows(){
    return this.http.get<TvShow[]>(`${this.baseUrl}/movie?min=${this.numberOfShowsLoaded + 1}&max=${this.numberOfShowsLoaded+=10}`);
  }

  search(term:string){
    return this.http.get<TvShow[]>(`${this.baseUrl}/movie?searchKey=${term}`);
  }

  get baseUrl(): string {
      return `${this.appConfig.appSettings.apiEndpoints.endpoint}`;
  }
}
