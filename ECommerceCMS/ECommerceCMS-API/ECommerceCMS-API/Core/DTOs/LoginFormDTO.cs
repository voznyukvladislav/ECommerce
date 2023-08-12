using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;

namespace ECommerceCMS_API.Core.DTOs
{
    public class LoginFormDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public LoginFormDTO()
        {

        }
        public LoginFormDTO(InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();

            this.Login = nameValue["LoginForm.Login"];
            this.Password = nameValue["LoginForm.Password"];
        }
    }
}
