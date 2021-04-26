import { Actor } from './actor';
import { MovieStar } from './movie-star';

export interface TvMovie {
  id: number;
  title: string;
  description: string;
  coverImageUrl: string
  releaseDate: Date;
  rating: number;
  calculatedRating: number;
  actors: Actor[];
  yourRate: number;
  yourRateId: number
}
