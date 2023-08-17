using ECommerceApp_API.Core.DTOs.InputDTOs;

namespace ECommerceApp_API.Core.Interfaces
{
    public interface IPopupService
    {
        public PopupDTO GetLoginPopup();
        public PopupDTO GetRegistrationPopup();
    }
}
