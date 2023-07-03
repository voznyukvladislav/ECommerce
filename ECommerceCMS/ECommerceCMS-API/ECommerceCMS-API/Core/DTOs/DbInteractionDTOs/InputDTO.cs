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

        public static InputDTO CreateSimple(string name, string placeholder)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Simple"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add("");
            inputDTO.Placeholders.Add(placeholder);

            return inputDTO;
        }
        public static InputDTO CreateSearch(string name, string placeholder, string tableName)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Search"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add("");
            inputDTO.Placeholders.Add(placeholder);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSearchResult}?tableName={tableName}");

            return inputDTO;
        }
        public static InputDTO CreateOneOfMany(string name, string placeholder, string tableName)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["OneOfMany"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add("");
            inputDTO.Placeholders.Add(placeholder);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");

            return inputDTO;
        }
        public static InputDTO CreateManyOfMany(string name, string placeholder, string tableName)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["ManyOfMany"];
            inputDTO.Names.Add(name);
            inputDTO.Values.Add("");
            inputDTO.Placeholders.Add(placeholder);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");

            return inputDTO;
        }
        public static InputDTO CreateSimpleWithSelector(string[] names, string[] placeholders, string tableName)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["ManyOfMany"];
            inputDTO.Names = names.ToList();
            inputDTO.Values.Add("");
            inputDTO.Values.Add("");
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");

            List<string> inputPlaceholders = placeholders.ToList();
            inputPlaceholders.ForEach(p =>
            {
                p += ": ";
            });
            inputDTO.Placeholders = inputPlaceholders;

            return inputDTO;
        }
        public static InputDTO CreateExtensional(string name, string placeholder, string tableName) {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = Constants.InputTypes["Extensional"];
            inputDTO.Names.Add(name);
            inputDTO.Placeholders.Add(placeholder);
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetSimpleDTO}?tableName={tableName}&pageNum={1}&pageSize={Constants.PageSize}");
            inputDTO.Links.Add($"{Constants.Url}/{Constants.GetInputGroups}");

            return inputDTO;
        }
    }
}
