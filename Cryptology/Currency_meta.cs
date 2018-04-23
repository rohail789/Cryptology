using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cryptology
{
    [MetadataTypeAttribute(typeof(Currency_meta))]
    public partial class Currency
    {

    }

    public class Currency_meta
    {
        [Required]
        [Display(Name ="Currency")]
        [Index(IsUnique = true)]
        public string Cname { get; set; }
        public decimal Price_usd { get; set; }
        public string Symbol { get; set; }
        [Index(IsUnique = true)]
        public Nullable<int> Rank { get; set; }
        public decimal Price_btc { get; set; }
        public Nullable<decimal> C24h_volume_usd { get; set; }
        public decimal Market_cap_usd { get; set; }
        public Nullable<decimal> Available_supply { get; set; }
        public Nullable<decimal> Max_supply { get; set; }
        public Nullable<decimal> Percent_change_7d { get; set; }
        public string Last_updated { get; set; }

    }
   
}