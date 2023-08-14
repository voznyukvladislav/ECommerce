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
        public string Name { get; set; } = string.Empty;
        public bool IsFilter { get; set; }
        public MeasurementSet? MeasurementSet { get; set; }
        public int? MeasurementSetId { get; set; }

        public List<Attribute_AttributeSet> Attribute_AttributeSet { get; set; } = new List<Attribute_AttributeSet>();

        public Attribute()
        {

        }
    }
}
