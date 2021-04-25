import { Component, Input, OnInit } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-rating-icon',
  templateUrl: './rating-icon.component.html',
  styleUrls: ['./rating-icon.component.scss']
})
export class RatingIconComponent implements OnInit {
  @Input() count: Number = 0; 
  @Input() clickable: string = "no";
  @Output() newItemEvent = new EventEmitter<number>();

  fakeArray: number[];
  constructor() { }

  ngOnInit(): void {
    this.fakeArray = new Array(5);
  }

  rateMovie(stars: number){
    this.newItemEvent.emit(stars);
    this.count = stars;
  }
}
