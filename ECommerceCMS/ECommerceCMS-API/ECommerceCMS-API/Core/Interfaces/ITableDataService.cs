using ECommerceCMS_API.Core.DTOs;
using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Core.Entities;

namespace ECommerceCMS_API.Core.Interfaces
{
    public interface ITableDataService
    {
        public string GetTableData(string tableName, int pageNum, int pageSize);
        public string GetTablePagesNumber(string tableName, int pageSize);
        public string GetSearchResult(string tableName, int input);
        public string GetSimpleDto(string tableName, int pageNum, int pageSize);
        public void InsertData(InputBlockDTO inputBlockDTO);
        public List<SimpleDTO> GetMeasurementsFromSet(int measurementSetId);
    }
}
