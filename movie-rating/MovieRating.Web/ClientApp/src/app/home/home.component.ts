import { Component, OnInit } from '@angular/core';
import { TvMovieApiService } from './services/api/tv-movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private tvMovieService: TvMovieApiService) { }

  ngOnInit(): void {
    this.tvMovieService.getTvMovie().pipe().subscribe(x=>{console.log(x)});
  }
}
