using Microsoft.OpenApi.Validations;

namespace ECommerceApp_API.Core.DTOs.InputDTOs
{
    public class InputDTO
    {        
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public bool Validatable { get; set; } = false;
        public string Validation { get; set; } = string.Empty;

        public static InputDTO CreateSimpleValidatable(string name, string placeholder, string validationRule)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = InputTypes.Simple;
            inputDTO.Name = name;
            inputDTO.Placeholder = placeholder;
            inputDTO.Validatable = true;
            inputDTO.Validation = validationRule;

            return inputDTO;
        }

        public static InputDTO CreatePasswordValidatable(string name, string placeholder, string validationRule)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = InputTypes.Password;
            inputDTO.Name = name;
            inputDTO.Placeholder = placeholder;
            inputDTO.Validatable = true;
            inputDTO.Validation = validationRule;

            return inputDTO;
        }

        public static InputDTO CreateSimple(string name, string placeholder)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = InputTypes.Simple;
            inputDTO.Name = name;
            inputDTO.Placeholder = placeholder;

            return inputDTO;
        }

        public static InputDTO CreatePassword(string name, string placeholder)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = InputTypes.Password;
            inputDTO.Name = name;
            inputDTO.Placeholder = placeholder;

            return inputDTO;
        }

        public static InputDTO CreateDoublePasswordValidatable(string name, string placeholder, string validationRule)
        {
            InputDTO inputDTO = new InputDTO();
            inputDTO.Type = InputTypes.DoublePassword;
            inputDTO.Name = name;
            inputDTO.Placeholder = placeholder;
            inputDTO.Validatable = true;
            inputDTO.Validation = validationRule;

            return inputDTO;
        }
    }
}
