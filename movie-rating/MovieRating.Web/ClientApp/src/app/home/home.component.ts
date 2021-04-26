import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TvMovie } from './models/tv-movie';
import { TvShow } from './models/tv-show';
import { TvMovieApiService } from './services/api/tv-movie.service';
import { TvShowApiService } from './services/api/tv-show.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  tvMovies: TvMovie[];
  tvShows: TvShow[];
  isTvShows: boolean = false;
  formGroup: FormGroup;

  constructor(private tvMovieService: TvMovieApiService, private tvShowService: TvShowApiService) { }

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      search: new FormControl(''),
      toggle: new FormControl(false)
    });

    this.tvMovieService.getTvMovie().pipe().subscribe(
      data=>{
        this.tvMovies = data;
      });
  }
}
