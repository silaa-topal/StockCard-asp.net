using System.ComponentModel.DataAnnotations;

namespace StokKartiProjesi.Models
{
    public class Stok
    {
        
        [Key]
        public string StokID { get; set; }

        [Required]
        public string? StokNO { get; set; }
        public string? StokAdi { get; set; }
        [Required(ErrorMessage = "Stok barkod giriniz")]
        public string? StokBarkod { get; set; }
        public string? StokAciklama { get; set; }

        //public int? GirenAdet { get; set; }

        //public int? CikanAdet { get; set; }

        //public string StokAdet { get; set; }
        public string? Birim { get; set; }

        public float KDV { get; set; }
        public float Fiyat1 { get; set; }
        public float Fiyat2 { get; set; }
        public float Fiyat3 { get; set; }
        public float Fiyat4 { get; set; }
        public float Fiyat5 { get; set; }
        
        public virtual List<Satis>? Satis { get; set; }
    }
}
