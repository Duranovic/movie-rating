import { Component, Input, OnInit } from '@angular/core';
import { TvMovie } from '../models/tv-movie';
import { MovieStar } from '../models/movie-star';

import { TvMovieApiService } from '../services/api/tv-movie.service';

@Component({
  selector: 'app-list-tv-movie',
  templateUrl: './list-tv-movie.component.html',
  styleUrls: ['./list-tv-movie.component.scss']
})
export class ListTvMovieComponent implements OnInit {
  @Input() searchedTvMovies: TvMovie [];
  tvMovies: TvMovie[];
  showRateMovie: boolean = false;
  constructor(private tvMovieService: TvMovieApiService ) { }

  ngOnInit(): void {
    this.tvMovieService.getTvMovie().pipe().subscribe(
      data=>{
        this.tvMovies = data;
        this.calculateRating(this.tvMovies);
      });
  }

  loadMoreItems(){
    this.tvMovieService.loadMoreTvMovies().pipe().subscribe(
      data=>{
        this.tvMovies.push(...data);
        this.calculateRating(this.tvMovies);
      }
    );
  }
  toggleShowRateMovie(){
    this.showRateMovie = !this.showRateMovie;
  }

  rateMovie(event:any, id:number, yourRateId: number){
    var movieStar : MovieStar = new MovieStar(id, event, yourRateId);
    this.tvMovieService.addRating(movieStar);
    for(let item of this.tvMovies){
      if(item.id == id){
          item.calculatedRating = Math.round((item.rating + event) / 2);
          item.yourRate = event;
      }
    }
  }

  calculateRating(array: any[]){
    for(let item of array){
      item.calculatedRating = Math.round((item.rating + item.yourRate) / 2);
    }
  }
}
