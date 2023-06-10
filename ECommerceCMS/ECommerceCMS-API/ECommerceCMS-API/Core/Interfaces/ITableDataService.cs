namespace ECommerceCMS_API.Core.Interfaces
{
    public interface ITableDataService
    {
        public string GetTableData(string tableName, int pageNum, int pageSize);
        public string GetTablePagesNumber(string tableName, int pageSize);
    }
}
