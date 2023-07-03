import { Constants } from "../constants";

export enum InputTypes {
    simple = "simple",
    oneOfMany = "oneOfMany",
    manyOfMany = "manyOfMany",
    simpleWithSelector = "simpleWithSelector",
    extensional = "extensional",
    search = "search"
}

export class InputDTO {
    type: string = '';
    values: string[] = [];
    names: string[] = [];
    links: string[] = [];
    placeholders: string[] = [];

    public static CreateSimple(name: string, placeholder: string): InputDTO {
        let input: InputDTO = new InputDTO();
        input.type = InputTypes.simple;
        input.names.push(name);
        input.placeholders.push(placeholder + ": ");

        return input;
    }
    public static CreateSearch(name: string, placeholder: string, tableName: string): InputDTO {
        let input: InputDTO = new InputDTO();
        input.type = InputTypes.search;
        input.names.push(name);
        input.placeholders.push(placeholder);
        input.links.push(`${Constants.url}/${Constants.tableSearchResult}?tableName=${tableName}`);
        input.values.push();

        return input;
    }
    public static CreateOneOfMany(name: string, placeholder: string, tableName: string): InputDTO {
        let input = new InputDTO();
        input.type = InputTypes.oneOfMany;
        input.names.push(name);
        input.links.push(`${Constants.url}/${Constants.getSimpleDto}?tableName=${tableName}&pageNum=${1}&pageSize=${20}`);
        input.placeholders.push(placeholder);

        return input;
    }
    public static CreateManyOfMany(name: string, placeholder: string, tableName: string): InputDTO {
        let input = new InputDTO();
        input.type = InputTypes.manyOfMany;
        input.names.push(name);
        input.links.push(`${Constants.url}/${Constants.getSimpleDto}?tableName=${tableName}&pageNum=${1}&pageSize=${20}`);
        input.placeholders.push(placeholder);

        return input;
    }
    public static CreateSimpleWithSelector(names: string[], placeholders: string[], tableName: string): InputDTO {
        let input = new InputDTO();
        input.type = InputTypes.simpleWithSelector;
        input.names = names;
        input.values.push();
        input.values.push();
        input.links.push(`${Constants.url}/${Constants.getSimpleDto}?tableName=${tableName}&pageNum=${1}&pageSize=${20}`);
        placeholders.forEach(p => {
            p = p + ": ";
        });
        input.placeholders = placeholders;

        return input;
    }
    public static CreateExtensional(name: string, placeholder: string, tableName: string): InputDTO {
        let input = new InputDTO();
        input.type = InputTypes.extensional;
        input.names.push(name);
        input.links.push(`${Constants.url}/${Constants.getSimpleDto}?tableName=${tableName}&pageNum=${1}&pageSize=${20}`);
        input.links.push(`${Constants.url}/${Constants.getInputGroups}`);
        input.placeholders.push(placeholder);

        return input;
    }
}