using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;

namespace ECommerceCMS_API.Core.Interfaces
{
    public interface IInputService
    {
        public IEnumerable<InputGroupDTO> GetInputGroups(int templateId);
        public InputBlockDTO GetInputBlock(string tableName);
    }
}
