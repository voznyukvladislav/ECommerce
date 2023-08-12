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
        
        public List<SimpleDTO> GetMeasurementsFromSet(int measurementSetId);

        public void InsertData(InputBlockDTO inputBlockDTO);
        public void InsertData(InputBlockDTO inputBlockDTO, out Message message);
        public void UpdateData(InputBlockDTO inputBlockDTO);
        public void UpdateData(InputBlockDTO inputBlockDTO, out Message message);
        public void DeleteData(string tableName, int id);
    }
}
