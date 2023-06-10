using ECommerceCMS_API.Infrastructure.Data;

namespace ECommerceCMS_API.Core.Interfaces
{
    public interface ITableMetaDataService
    {
        public string GetTableMetadata(string tableName);
    }
}
