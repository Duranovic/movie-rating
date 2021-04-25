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
      });
  }

  loadMoreItems(){
    this.tvMovieService.loadMoreTvMovies().pipe().subscribe(
      data=>this.tvMovies.push(...data)
    );
  }
  toggleShowRateMovie(){
    this.showRateMovie = !this.showRateMovie;
  }

  rateMovie(event:any, id:number, yourRateId: number){
    var movieStar : MovieStar = new MovieStar(id, event, yourRateId);
    this.tvMovieService.addRating(movieStar);
  }
}
