namespace ECommerceApp_API.Core.DTOs.FilterDTO
{
    public class SortingDTO
    {
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; } = false;

        public static List<SortingDTO> GetSortingDTOs()
        {
            return new List<SortingDTO>
            {
                new SortingDTO
                {
                    Name = SortingDTONames.Alphabetical,
                    IsSelected = true
                },
                new SortingDTO
                {
                    Name = SortingDTONames.Ascending
                },
                new SortingDTO
                {
                    Name = SortingDTONames.Descending
                }
            };
        }
    }
}
