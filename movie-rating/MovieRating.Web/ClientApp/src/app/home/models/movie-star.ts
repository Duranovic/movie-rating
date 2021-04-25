export class MovieStar {
  id: number;
  movieId: number;
  stars: number;
  constructor(id:number, stars: number, yourRateId:number) {
      this.id = yourRateId ?? 0;
      this.movieId = id;
      this.stars = stars;
  }
}
