export class Constants {
    static url: string = "https://localhost:7275/api";

    static tableMetadata: string = "tableMetadata/getTableMetadata";

    static tableData: string = "tableData/getTableData";

    static pagesNumber: string = "tableData/getPagesNumber";

    static tableSearchResult: string = "tableData/getSearchResult";

    static getSimpleDto: string = "tableData/getSimpleDto";

    static getInputGroups: string = "inputs/getInputGroups";

    static getInputBlock: string = "inputs/getInputBlock";

    static getUpdateInputBlock: string = "inputs/getInputUpdateBlock";

    static insertData: string = "tableData/insertData";

    static updateData: string = "tableData/updateData";

    static deleteData: string = "tableData/deleteData";
}

export enum TableNames {
    Attributes = "Attributes",
    AttributeSets = "AttributeSets",
    Categories = "Categories",
    Discounts = "Discounts",
    Measurements = "Measurements",
    MeasurementSets = "MeasurementSets",
    Orders = "Orders",
    Photos = "Photos",
    Products = "Products",
    Reviews = "Reviews",
    Roles = "Roles",
    ShoppingCarts = "ShoppingCarts",
    SubCategories = "SubCategories",
    Templates = "Templates",
    Users = "Users",
    Values = "Values"
}