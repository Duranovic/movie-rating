import { Component, Input, OnInit } from '@angular/core';
import { TvShow } from '../models/tv-show';
import { TvShowApiService } from '../services/api/tv-show.service';

@Component({
  selector: 'app-list-tv-show',
  templateUrl: './list-tv-show.component.html',
  styleUrls: ['./list-tv-show.component.scss']
})
export class ListTvShowComponent implements OnInit {
  @Input() searchedTvShows: TvShow[];
  tvShows: TvShow[];

  constructor(private tvShowService: TvShowApiService) { }

  ngOnInit(): void {
    this.tvShowService.getTvShow().pipe().subscribe(
      data=>{
        this.tvShows = data;
        console.log(this.tvShows);
      });
  }

  loadMoreItems(){
    this.tvShowService.loadMoreTvShows().pipe().subscribe(
      data=>this.tvShows.push(...data)
    );
  }
}
