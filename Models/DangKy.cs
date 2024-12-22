using System;
using System.Collections.Generic;

namespace Sinhvien.Models
{
    public partial class DangKy
    {
        public DangKy()
        {
            MaHps = new HashSet<HocPhan>();
        }

        public int MaDk { get; set; }
        public DateTime? NgayDk { get; set; }
        public string? MaSv { get; set; }

        public virtual SinhVien? MaSvNavigation { get; set; }

        public virtual ICollection<HocPhan> MaHps { get; set; }
    }
}
