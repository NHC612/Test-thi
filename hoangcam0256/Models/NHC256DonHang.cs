using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hoangcam0256.Models
{
    public class NHC256DonHang
    {
        [Key]
        public string NHC256MaDonHang {get; set;}
        public int NHC256TenSanPham {get; set;}
        [ForeignKey("NHC256TenSanPham")]
        public NHC256SanPham? NHC256SanPham {get; set;}
        public string NHC256TenKhachHang {get; set;}

    }
}
    