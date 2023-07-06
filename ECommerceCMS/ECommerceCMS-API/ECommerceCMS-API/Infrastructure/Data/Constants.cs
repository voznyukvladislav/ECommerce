namespace ECommerceCMS_API.Infrastructure.Data
{
    public static class Constants
    {
        public static string Url { get; set; } = "https://localhost:7275/api";
        public static string GetMeasurementsFromSet { get; } = "tableData/getMeasurementsFromSet";
        public static string GetSimpleDTO { get; } = "tableData/getSimpleDto";
        public static string GetInputGroups { get; } = "inputs/getInputGroups";
        public static string GetSearchResult { get; } = "tableData/getSearchResult";

        public static int PageSize { get; } = 20;

        public static Dictionary<string, string> InputTypes { get; } = new Dictionary<string, string> {
            { "Simple", "simple" },
            { "OneOfMany", "oneOfMany" },
            { "ManyOfMany", "manyOfMany" },
            { "SimpleWithSelector", "simpleWithSelector" },
            { "Extensional", "extensional" },
            { "Search", "search" },
            { "Static", "static" }
        };
        public static Dictionary<string, string> TableNames { get; } = new Dictionary<string, string>
        {
            { "Attributes", "Attributes" },
            { "AttributeSets", "AttributeSets" },
            { "Categories", "" },
            { "Discounts", "" },
            { "Measurements", "" },
            { "MeasurementSets", "" },
            { "Orders", "" },
            { "Photos", "" },
            { "Products", "" },
            { "Reviews", "" },
            { "Roles", "" }
        };
    }
}
