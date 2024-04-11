import { BookModel } from "./bookModel";

export class AuthorModel{
    id: string = '';
    fullName: string = '';
    birthDate: Date = new Date();
    description: string = '';
    image: string = '';
    books: BookModel[] = [];
}