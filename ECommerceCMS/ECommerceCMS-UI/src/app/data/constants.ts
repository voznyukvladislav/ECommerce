export class Constants {
    // Connection constants beginning
    static url: string = "https://localhost:7275/api";

    static tableMetadata: string = "tableMetadata/getTableMetadata";

    static tableData: string = "tableData/getTableData";
    static pagesNumber: string = "tableData/getPagesNumber";
    static tableSearchResult: string = "tableData/getSearchResult";
    static getSimpleDto: string = "tableData/getSimpleDto";
    static insertData: string = "tableData/insertData";
    static updateData: string = "tableData/updateData";
    static deleteData: string = "tableData/deleteData";

    static getInputGroups: string = "inputs/getInputGroups";
    static getInputBlock: string = "inputs/getInputBlock";
    static getUpdateInputBlock: string = "inputs/getInputUpdateBlock";
    static getLoginInputBlock: string = "inputs/getLoginInputBlock";

    static login: string = "login/login";
    static logout: string = "login/logout";
    static isAuthorized: string = "login/isAuthorized";
    // Connection constants end

    // Status messages beginning
    static successful = "Successful";
    static failed = "Failed";
    // Status messages end
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