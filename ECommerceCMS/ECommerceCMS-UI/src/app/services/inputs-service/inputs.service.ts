import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Constants, TableNames } from 'src/app/data/constants';
import { InputDTO } from 'src/app/data/input/input-dto';
import { InputBlockDTO } from 'src/app/data/input/input-block';

@Injectable({
  providedIn: 'root'
})
export class InputsService {
  constructor(private http: HttpClient) { }

  // getInputsBlock(tableName: string) : InputsBlock {
  //   this.inputsBlock = new InputsBlock();
  //   this.inputsBlock.title = tableName;
    
  //   switch(tableName) {      
  //     case "attributes": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Attribute.Name", "Enter name"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Attribute.MeasurementSetId", "Select measurement set", TableNames.MeasurementSets));
        
  //       break;
  //     }
  //     case "attributeSets": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("AttributeSet.Name", "Enter attribute set name"));
  //       this.inputsBlock.inputs.push(Input.CreateManyOfMany("AttributeSet.Attributes", "Select attributes", TableNames.Attributes));
        
  //       break;
  //     }
  //     case "categories": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Category.Name", "Enter category name"));

  //       break;
  //     }
  //     case "discounts": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Discount.Value", "Enter discount value (0.0 - 1.0)"));        

  //       break;
  //     }
  //     case "measurements": {    
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Measurement.Name", "Enter measurement name"));

  //       break;
  //     }
  //     case "measurementSets": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("MeasurementSet.Name", "Enter measurement set name"));
  //       this.inputsBlock.inputs.push(Input.CreateManyOfMany("MeasurementSet.Measurements", "Select measurements", TableNames.Measurements));
        
  //       break;
  //     }
  //     case "orders": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Order.Date", "Enter order date"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Order.UserId", "Select user", TableNames.Users));
  //       this.inputsBlock.inputs.push(Input.CreateManyOfMany("Order.Products", "Select products", TableNames.Products));
        
  //       break;
  //     }
  //     case "photos": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Photo.Source", "Enter photo source"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Photo.ProductId", "Select product", TableNames.Products));
        
  //       break;
  //     }
  //     case "products": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Product.Name", "Enter product name"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Product.Price", "Enter product price"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Product.SubCategoryId", "Select subcategory", TableNames.SubCategories));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Product.Discount", "Select discount", TableNames.Discounts));
  //       this.inputsBlock.inputs.push(Input.CreateExtensional("Product.TemplateId", "Select template", TableNames.Templates));

  //       break;
  //     }
  //     case "reviews": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Review.Text", "Enter review text"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Review.Rating", "Enter review rating"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Review.UserId", "Select user", TableNames.Users));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Review.ProductId", "Select product", TableNames.Products));
        
  //       break;
  //     }
  //     case "roles": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Role.Name", "Enter role name"));

  //       break;
  //     }
  //     case "shoppingCarts": {
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("ShoppingCart.UserId", "Select user", TableNames.Users));
  //       this.inputsBlock.inputs.push(Input.CreateManyOfMany("ShoppingCart.Products", "Select products", TableNames.Products));

  //       break;
  //     }
  //     case "subcategories": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("SubCategory.Name", "Enter subcategory name"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("SubCategory.CategoryId", "Select category", TableNames.Categories));

  //       break;
  //     }
  //     case "templates": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Template.Name", "Enter template name"));
  //       this.inputsBlock.inputs.push(Input.CreateManyOfMany("Template.AttributeSets", "Select attribute sets", TableNames.AttributeSets));

  //       break;
  //     }
  //     case "users": {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("User.Name", "Enter user name"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("User.Surname", "Enter user surname"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("User.Login", "Enter user login"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("User.Password", "Enter user password"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("User.Email", "Enter user email"));
  //       this.inputsBlock.inputs.push(Input.CreateSimple("User.Phone", "Enter user phone"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("User.RoleId", "Select role", TableNames.Roles));

  //       break;
  //     }
  //     case "values" : {
  //       this.inputsBlock.inputs.push(Input.CreateSimple("Value.Val", "Enter value"));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Value.ProductId", "Select product", TableNames.Products));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Value.AttributeSetId", "Select attribute set", TableNames.AttributeSets));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("Value.AttributeId", "Select attribute", TableNames.Attributes));
  //       this.inputsBlock.inputs.push(Input.CreateOneOfMany("value.MeasurementId", "Select measurement", TableNames.Measurements));

  //       break;
  //     }
  //     default: {
  //       break;
  //     }
  //   }
    
  //   return this.inputsBlock;
  // }
  getInputBlock(tableName: string) {
    return this.http.get(`${Constants.url}/${Constants.getInputBlock}?tableName=${tableName}`);
  }

  getInputGroups(templateId: number) {
    return this.http.get(`${Constants.url}/${Constants.getInputGroups}?templateId=${templateId}`)
  }

  getUpdateInputBlock(tableName: string, id: string) {
    return this.http.get(`${Constants.url}/${Constants.getUpdateInputBlock}?tableName=${tableName}&id=${id}`);
  }
 }
