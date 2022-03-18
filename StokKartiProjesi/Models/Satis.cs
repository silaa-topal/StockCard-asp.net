using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokKartiProjesi.Models
{
    public class Satis
    {
        [Key]
        public int SatisID { get; set; }
        
        public string? StokID { get; set; }

        public string? IslemTipi { get; set; }

        public DateTime Tarih { get; set; }

        public int Miktar { get; set; }

        public int BirimFiyatı { get; set; }

        public int ToplamFiyat { get; set; }



        public virtual Stok? Stok { get; set; }
    }
}
