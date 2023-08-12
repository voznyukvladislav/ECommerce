using ECommerceCMS_API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace ECommerceCMS_API.Core.DTOs.DbInteractionDTOs
{
    public class InputDTO
    {
        public string Type { get; set; } = string.Empty;
        public List<string> Values { get; set; } = new List<string>();
        public List<string> Names { get; set; } = new List<string>();
        public List<string> Links { get; set; } = new List<string>();
        public List<string> Placeholders { get; set; } = new List<string>();
        public static InputDTO CreateStatic(string name, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Static"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);

            return inputDTO;
        }

        public static InputDTO CreateSimple(string name, string placeholder, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Simple"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);

            return inputDTO;
        }
        public static InputDTO CreateSimplePassword(string name, string placeholder, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Password"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);

            return inputDTO;
        }
        public static InputDTO CreateBoolean(string name, string placeholder, string value = "false")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Boolean"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);

            return inputDTO;
        }
        public static InputDTO CreateSearch(string name, string placeholder, string tableName, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Search"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSearchResult}?tableName={tableName}");

            return inputDTO;
        }
        public static InputDTO CreateOneOfMany(string name, string placeholder, string tableName, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["OneOfMany"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);
            //inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}");
            return inputDTO;
        }
        public static InputDTO CreateManyOfMany(string name, string placeholder, string tableName, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["ManyOfMany"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);
            //inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}");


            return inputDTO;
        }
        public static InputDTO CreateSimpleWithSelector(string[] names, string[] placeholders, string tableName, string value = "")
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["ManyOfMany"];
            inputDTO.Names = names.ToList();
            inputDTO.Values.Add(value);
            inputDTO.Values.Add(value);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");

            List<string> inputPlaceholders = placeholders.ToList();
            inputPlaceholders.ForEach(p =>
            {
                p += ": ";
            });
            inputDTO.Placeholders = inputPlaceholders;

            return inputDTO;
        }
        public static InputDTO CreateExtensional(string name, string placeholder, string tableName, string value = "") {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Extensional"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add(value);
            inputDTO.Placeholders.Add(placeholder);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetInputGroups}");

            return inputDTO;
        }        
    }
}
