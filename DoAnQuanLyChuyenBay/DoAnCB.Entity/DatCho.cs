using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.Entity
{
    [Table("DatCho")]
    public class DatCho
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime? NgayVe { get; set; }
        public int ChuyenBayID { get; set; }
        public int KhachHangID { get; set; }
    }
}
