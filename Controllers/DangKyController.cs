using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sinhvien.Models;

namespace Sinhvien.Controllers
{
    public class DangKyController : Controller
    {
        private readonly Test1Context _context;

        public DangKyController(Test1Context context)
        {
            _context = context;
        }

        // GET: DangKy/ListHP
        public async Task<IActionResult> ListHP(string maSv)
        {
            if (string.IsNullOrEmpty(maSv))
            {
                return NotFound();
            }

            // Lấy thông tin sinh viên và các học phần đã đăng ký
            var dangKys = await _context.DangKies
                .Include(dk => dk.MaSvNavigation) // Lấy thông tin sinh viên
                .Include(dk => dk.MaHps) // Lấy các học phần đã đăng ký
                .Where(dk => dk.MaSv == maSv)
                .ToListAsync();

            if (dangKys == null || !dangKys.Any())
            {
                return NotFound();
            }

            return View(dangKys);
        }
    }
}
