import { Genre } from "../enums/genre";
import { AuthorModel } from "./authorModel";
import { PublisherModel } from "./publisherModel";

export class UpdateBookModel{
    id: string = '';
    name: string = '';
    path: string = '';
    description: string = '';
    genre: Genre = Genre.Genre1;
    yearOfEdition: number = 0;
    pageAmount: number = 0;
    image: File | null = null; 
    publisherId: string | null = null;
}