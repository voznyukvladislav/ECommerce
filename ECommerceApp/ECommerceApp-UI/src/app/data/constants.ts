export class Constants {
    // Constant sizes
    public static inputFilterHeight: number = 30;
    public static attributeFilterHeight: number = 20;

    // API constants
    public static api: string = "https://localhost:7041/api";
    
    // Controllers and methods start
    // Menu controller
    public static menu: string = "menu";

    public static getCategories: string = "getCategories";
    public static getSubCategories: string = "getSubCategories";

    // Login controller
    public static login: string = "login";

    public static getLoginPopup: string = "getLoginPopup";
    public static getRegistrationPopup: string = "getRegistrationPopup";
    public static register: string = "register";
    public static logOut: string = "logOut";
    public static isAuthorized: string = "isAuthorized";

    // Db data controller
    public static data: string = "data";

    public static getSubCategoryParent: string = "getSubCategoryParent";
    public static getSubCategory: string = "getSubCategory";

    // Product controller
    public static product: string = "product";
    
    public static getProduct: string = "getProduct";
    public static getProductRating: string = "getProductRating";

    // Review controller
    public static review: string = "review";

    public static getReviews: string = "getReviews";
    public static addReview: string = "addReview";

    // Shopping cart controller
    public static shoppingCart: string = "shoppingCart";

    public static getShoppingCart: string = "getShoppingCart";
    public static addShoppingCartProduct: string = "addShoppingCartProduct";
    public static removeShoppingCartProduct: string = "removeShoppingCartProduct";
    public static updateShoppingCartProductCount: string = "updateShoppingCartProductCount"

    // Filter controller
    public static filter: string = "filter";

    public static getSortings: string = "getSortings";
    public static getFilters: string = "getFilters";
    public static getProducts: string = "getProducts";

    // Controllers and methods end
}