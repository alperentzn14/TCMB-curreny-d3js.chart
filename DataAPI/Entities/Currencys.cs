using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Provision.Entities
{
    public class Currency : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RecordId { get; set; }
        public DateTime InsertDate { get; set; }
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public decimal ForexBuyingAmount { get; set; }
        public decimal ForexSellingAmount { get; set; }
        public decimal EffectiveBuyingAmount { get; set; }
        public decimal EffectiveSellingAmount { get; set; }
    }
}
