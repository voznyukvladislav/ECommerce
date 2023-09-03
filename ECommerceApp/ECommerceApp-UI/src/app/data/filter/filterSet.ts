import { AttributeSetFilter } from "./attributeSetFilter";
import { PriceFilter } from "./priceFIlter";

export class FilterSet {
    sortingType: string = "";
    priceFilter: PriceFilter = new PriceFilter();
    attributeSetFilters: AttributeSetFilter[] = [];
}