import { ProductAttributeSet } from "./productAttributeSet";
import { Review } from "./review";

export class ProductFull {
    id: number = 0;
    name: string = "";
    rating: number = 0;
    reviewsCount: number = 0;
    basePrice: string = "";
    price: string = "";
    photos: string[] = [];
    attributeSets: ProductAttributeSet[] = [];
    reviews: Review[] = [];
}