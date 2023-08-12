using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;

namespace ECommerceCMS_API.Core.Interfaces
{
    public interface IInputService
    {
        public IEnumerable<InputGroupDTO> GetInputGroups(int templateId);
        public InputBlockDTO GetLoginInputBlock();
        public InputBlockDTO GetInputBlock(string tableName);
        public InputBlockDTO GetUpdateInputBlock(string tableName, int id);
    }
}
