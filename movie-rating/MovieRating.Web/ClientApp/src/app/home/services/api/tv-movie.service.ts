import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/app-config';

import { TvMovie } from '../../models/tv-movie';
import { MovieStar } from '../../models/movie-star';


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

    addRating(movieStar: MovieStar){
      if(movieStar.id == 0){
        return this.http.post<MovieStar>(`${this.baseUrl}/movie`, movieStar).subscribe(data=>{
          console.log(data);
        });
      }else{
        return this.http.put<MovieStar>(`${this.baseUrl}/movie`, movieStar).subscribe(data=>{
          console.log(data);
        });
      }
    }

    get baseUrl(): string {
        return `${this.appConfig.appSettings.apiEndpoints.endpoint}`;
    }
}