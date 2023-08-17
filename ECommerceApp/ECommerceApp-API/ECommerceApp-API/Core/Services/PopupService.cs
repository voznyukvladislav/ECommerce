using ECommerceApp_API.Core.DTOs.InputDTOs;
using ECommerceApp_API.Core.Interfaces;

namespace ECommerceApp_API.Core.Services
{
    public class PopupService : IPopupService
    {
        public PopupDTO GetLoginPopup()
        {
            PopupDTO popupDTO = new PopupDTO();
            popupDTO.Title = "Log In";
            popupDTO.Inputs.Add(InputDTO.CreateSimple("InputDTO.Login", "Enter login or email"));
            popupDTO.Inputs.Add(InputDTO.CreatePassword("InputDTO.Password", "Enter password"));
            
            popupDTO.Buttons.Add(new Button("Registration"));

            return popupDTO;
        }

        public PopupDTO GetRegistrationPopup()
        {
            PopupDTO popupDTO = new PopupDTO();
            popupDTO.Title = "Registration";
            popupDTO.Inputs.Add(InputDTO.CreateSimpleValidatable("InputDTO.Email", "Enter email", ""));
            popupDTO.Inputs.Add(InputDTO.CreateSimpleValidatable("InputDTO.Login", "Enter login", ""));
            popupDTO.Inputs.Add(InputDTO.CreateSimple("InputDTO.Name", "Enter your name"));
            popupDTO.Inputs.Add(InputDTO.CreateSimple("InputDTO.Surname", "Enter your surname"));
            popupDTO.Inputs.Add(InputDTO.CreateSimple("InputDTO.Phone", "Enter your phone"));
            popupDTO.Inputs.Add(InputDTO.CreateDoublePasswordValidatable("InputDTO.Password", "Enter password", ""));

            popupDTO.Buttons.Add(new Button("Log In"));

            return popupDTO;
        }
    }
}
