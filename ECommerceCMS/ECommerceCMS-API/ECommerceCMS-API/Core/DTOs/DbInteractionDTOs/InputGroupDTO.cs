namespace ECommerceCMS_API.Core.DTOs.DbInteractionDTOs
{
    public class InputGroupDTO
    {
        public string CommonValue { get; set; } = string.Empty;
        public string CommonName { get; set; } = string.Empty;
        public List<InputDTO> InputDTOs { get; set; } = new List<InputDTO>();
    }
}
