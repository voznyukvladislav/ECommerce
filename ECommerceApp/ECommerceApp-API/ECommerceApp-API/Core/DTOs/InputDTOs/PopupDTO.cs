namespace ECommerceApp_API.Core.DTOs.InputDTOs
{
    public class PopupDTO
    {
        public string Title { get; set; } = string.Empty;
        public List<InputDTO> Inputs { get; set; } = new();
        public List<Button> Buttons { get; set; } = new();
        
        public static Dictionary<string, string> GetDictionaryFromPopup(PopupDTO popupDTO)
        {
            Dictionary<string, string> inputValue = new Dictionary<string, string>();
            popupDTO.Inputs.ForEach(input =>
            {
                inputValue.Add(input.Name, input.Value);
            });

            return inputValue;
        }
    }
}
