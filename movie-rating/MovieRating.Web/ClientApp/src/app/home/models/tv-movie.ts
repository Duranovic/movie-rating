import { Actor } from './actor';

export interface TvMovie {
  id: string;
  title: string;
  description: string;
  coverImage: string
  releaseDate: Date;
  rating: number;
  actors: Actor[];
  addedStars: number;
}
