namespace ECommerceApp_API.Core.DTOs.InputDTOs
{
    public class PopupDTO
    {
        public string Title { get; set; } = string.Empty;
        public List<InputDTO> Inputs { get; set; } = new();
        public List<Button> Buttons { get; set; } = new();
    }
}
