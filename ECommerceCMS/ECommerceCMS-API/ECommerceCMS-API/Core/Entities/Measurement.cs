using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Azure.Core.HttpHeader;

namespace ECommerceCMS_API.Core.Entities
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MeasurementSet> MeasurementSets { get; set; } = new List<MeasurementSet>();
        public List<Value> Values { get; set; } = new List<Value>();

        public Measurement()
        {
        }
        public Measurement(InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();

            if (nameValue.ContainsKey("Measurement.Id"))
                this.Id = Int32.Parse(nameValue["Measurement.Id"]);

            this.Name = nameValue["Measurement.Name"];
        }
    }
}
