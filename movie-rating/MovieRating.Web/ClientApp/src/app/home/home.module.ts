import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home.component';
import { TvMovieApiService } from './services/api/tv-movie.service';
import { TvShowApiService } from './services/api/tv-show.service';
import { ListTvMovieComponent } from './list-tv-movie/list-tv-movie.component';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatCardModule} from '@angular/material/card';
import { ListTvShowComponent } from './list-tv-show/list-tv-show.component';
import {MatTooltipModule} from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RatingIconComponent } from './rating-icon/rating-icon.component'


@NgModule({
  declarations: [
    HomeComponent,
    ListTvMovieComponent,
    ListTvShowComponent,
    RatingIconComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatTooltipModule,
    MatInputModule,
    MatSlideToggleModule,
    MatCardModule,
    MatIconModule,
    MatListModule
  ],
  providers: [
    TvMovieApiService,
    TvShowApiService
  ]
})
export class HomeModule { }
