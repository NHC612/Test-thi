using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hoangcam0256.Models
{
    public class NHC256SanPham
    {
        [Key]
        public int NHC256MaSanPham {get; set;}
        public string NHC256TenSanPham {get; set;}
        public float NHC256Address {get; set;}


    }

}