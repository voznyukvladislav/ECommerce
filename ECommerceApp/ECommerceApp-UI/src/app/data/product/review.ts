import { User } from "./user";

export class Review {
    text: string = "";
    rating: number = 0;
    reviewDate: string = "";
    user: User = new User();
}