using System;
using System.Collections.Generic;

namespace Sinhvien.Models
{
    public partial class HocPhan
    {
        public HocPhan()
        {
            MaDks = new HashSet<DangKy>();
        }

        public string MaHp { get; set; } = null!;
        public string TenHp { get; set; } = null!;
        public int? SoTinChi { get; set; }

        public virtual ICollection<DangKy> MaDks { get; set; }
    }
}
