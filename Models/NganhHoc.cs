using System;
using System.Collections.Generic;

namespace Sinhvien.Models
{
    public partial class NganhHoc
    {
        public NganhHoc()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaNganh { get; set; } = null!;
        public string? TenNganh { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
