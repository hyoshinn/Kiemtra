using System;
using System.Collections.Generic;

namespace Sinhvien.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            DangKies = new HashSet<DangKy>();
        }

        public string MaSv { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? Hinh { get; set; }
        public string? MaNganh { get; set; }

        public virtual NganhHoc? MaNganhNavigation { get; set; }
        public virtual ICollection<DangKy> DangKies { get; set; }
    }
}
