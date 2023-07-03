using ECommerceCMS_API.Core.DTOs.DbInteractionDTOs;
using ECommerceCMS_API.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace ECommerceCMS_API.Core.Entities
{
    public class MeasurementSet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();

        public MeasurementSet()
        {

        }
        public MeasurementSet(ECommerceDbContext db, InputBlockDTO inputBlockDTO)
        {
            Dictionary<string, string> nameValue = inputBlockDTO.GetNameValueDictionary();

            if (nameValue.ContainsKey("MeasurementSet.Id"))
                this.Id = Int32.Parse(nameValue["MeasurementSet.Id"]);
            if (nameValue.ContainsKey("MeasurementSet.Measurements"))
            {
                if (!String.IsNullOrEmpty(nameValue["MeasurementSet.Measurements"]))
                {
                    List<string> idList = (nameValue["MeasurementSet.Measurements"])
                        .Split(' ')
                        .ToList();

                    idList.ForEach(i =>
                    {
                        Measurement measurement = db.Measurements.Where(m => m.Id == Int32.Parse(i)).First();
                        this.Measurements.Add(measurement);
                    });
                }                    
            }

            this.Name = nameValue["MeasurementSet.Name"];
        }
    }
}
