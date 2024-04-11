import { BookModel } from "./bookModel";

export class PublisherModel{
    id: string = '';
    name: string = '';
    description: string = '';
    image: string | null = '';
    publishedBooks: BookModel[] = [];
}