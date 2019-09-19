using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DevExtremeMvcApp1.Models
{
    public class Arac
    {
        [Key]
        public int AracID { get; set; }
        [Required(ErrorMessage = "Marka is Required.")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Model is Required.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Motor Tipi is Required.")]
        public string MotorTipi { get; set; }
        [Required(ErrorMessage = "Plaka is Required.")]
        public string Plaka { get; set; }
        [Required(ErrorMessage = "Ruhsat Sahibi Adı is Required.")]
        public string RuhsatSahibiAdi { get; set; }
        [Required(ErrorMessage = "Ruhsat Sahibi Soyadı is Required.")]
        public string RuhsatSahibiSoyadi { get; set; }
        [Required(ErrorMessage = "Yıl  is Required.")]
        public string yil { get; set; }
        [Required(ErrorMessage = "Km is Required.")]
        public int km { get; set; }

        public TicariBinek TicariBinek { get; set; }

        public YakitTürü YakitTürü{ get; set; }
        public SurusTipi SurusTipi { get; set; }

       public BakimServisi Bakimservisi { get; set; }
    }
    public enum TicariBinek
    {
        Ticari,Binek
    }
    public enum YakitTürü
    {
        Benzin,Lpg,Dizel
    }
    public enum SurusTipi
    {
        Otomatik,Manuel
    }
    public enum BakimServisi
    {
        YetkiliServis,OzelServis
    }
}