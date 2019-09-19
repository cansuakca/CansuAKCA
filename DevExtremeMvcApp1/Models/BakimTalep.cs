using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevExtremeMvcApp1.Models
{
    [Table("BakimTalep")]
    public class BakimTalep
    {
        [Key]
        public int TalepID { get; set; }
        public int AracID { get; set; }
        public int UserID { get; set; }
        public DateTime TalepTarihi { get; set; }
        public String TalepDetay { get; set; }
        public Boolean TalepDurum { get; set; }
        public virtual Arac Arac { get; set; }
        public virtual UserAccount UserAccount{ get; set; }

    }
}