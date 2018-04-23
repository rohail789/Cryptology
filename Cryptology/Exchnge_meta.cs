using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cryptology
{
    [MetadataTypeAttribute(typeof(Exchnge_meta))]
    public partial class Exchnge
    {

    }
    public class Exchnge_meta
    {
        [Required]
        [DisplayName("Exchange Name")]
        public string ename { get; set; }
    }
   
}