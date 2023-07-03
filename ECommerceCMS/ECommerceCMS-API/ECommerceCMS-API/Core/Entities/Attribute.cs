using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Azure.Core.HttpHeader;

namespace ECommerceCMS_API.Core.Entities
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasurementSet? MeasurementSet { get; set; }
        public int? MeasurementSetId { get; set; }

        public List<Attribute_AttributeSet> Attribute_AttributeSet { get; set; } = new List<Attribute_AttributeSet>();

        public Attribute()
        {

        }
        public Attribute(InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();

            if (nameValue.ContainsKey("Attribute.Id"))
                this.Id = Int32.Parse(nameValue["Attribute.Id"]);

            this.Name = nameValue["Attribute.Name"];
            if(nameValue.ContainsKey("Attribute.MeasurementSetId"))
                this.MeasurementSetId = Int32.Parse(nameValue["Attribute.MeasurementSetId"]);
        }
    }
}
