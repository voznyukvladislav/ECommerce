namespace ECommerceCMS_API.Core.DTOs.DbInteractionDTOs
{
    public class InputBlockDTO
    {
        public string Title { get; set; } = string.Empty;
        public List<InputDTO> InputDTOs { get; set; } = new List<InputDTO>();
        public List<InputGroupDTO>? InputGroupDTOs { get; set; }

        public Dictionary<string, string> GetNameValueDictionary()
        {
            Dictionary<string, string> nameValue = new Dictionary<string, string>();
            this.InputDTOs.ForEach(input =>
            {
                List<string> names = input.Names.ToList();
                List<string> values = input.Values.ToList();

                // names.Count == values.Count / true
                for (int i = 0; i < names.Count; i++)
                {
                    if (!String.IsNullOrEmpty(names[i]) && !String.IsNullOrEmpty(values[i]))
                        nameValue.Add(names[i], values[i]);
                }                
            });

            return nameValue;
        }

        public List<Dictionary<string, string>> GetInputGroupValueDictionary()
        {
            List<Dictionary<string, string>> nameValueList = new List<Dictionary<string, string>>();
            this.InputGroupDTOs.ForEach(inputGroup =>
            {                
                inputGroup.InputDTOs.ForEach(input =>
                {
                    Dictionary<string, string> nameValue = new Dictionary<string, string>();
                    nameValue.Add("Value.AttributeSetId", $"{inputGroup.CommonValue}");

                    List<string> names = input.Names.ToList();
                    List<string> values = input.Values.ToList();

                    // names.Count == values.Count / true
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(names[i]) && !String.IsNullOrEmpty(values[i]))
                            nameValue.Add(names[i], values[i]);
                    }

                    nameValueList.Add(nameValue);
                });
            });

            return nameValueList;
        }
    }
}
