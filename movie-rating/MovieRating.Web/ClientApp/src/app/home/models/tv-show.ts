import { Actor } from './actor';

export interface TvShow {
  id: number;
  title: string;
  coverImageUrl: string
  description: string;
  rating: number;
  actors: Actor[];
  startDate: Date;
  endDate: Date;
}
