namespace ECommerceApp_API.Core.DTOs.InputDTOs
{
    public class Button
    {
        public string Name { get; set; } = string.Empty;

        public Button(string name)
        {
            this.Name = name;
        }
    }
}
