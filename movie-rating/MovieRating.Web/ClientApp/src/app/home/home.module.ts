import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { TvMovieApiService } from './services/api/tv-movie.service';
import { TvShowService } from './services/api/tv-show.service';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    TvMovieApiService,
    TvShowService
  ]
})
export class HomeModule { }
