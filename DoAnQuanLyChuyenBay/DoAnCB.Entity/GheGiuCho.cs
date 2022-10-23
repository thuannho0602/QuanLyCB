using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Entity
{
    [Table("GheGiuCho")]
    public class GheGiuCho
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MaCho { get; set; }
        public int DatChoId { get; set; }
    }
}
