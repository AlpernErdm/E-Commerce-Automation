using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int Faturaİd { get; set; }

        [Column(TypeName = "Varchar")] //Kısıtlamalar
        [StringLength(6)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")] //Kısıtlamalar
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }


        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")] //Kısıtlamalar
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")] //Kısıtlamalar
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = "char")] //Kısıtlamalar
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")] //Kısıtlamalar
        [StringLength(30)]
        public string TeslimAlan { get; set; }
       
        [Column(TypeName = "decimal")] //
        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; } 
    }
}