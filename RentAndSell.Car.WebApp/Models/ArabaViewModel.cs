using RentAndSell.Car.WebApp.Models.Commons.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentAndSell.Car.WebApp.Models
{
    public class ArabaViewModel
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public MotorTipi MotorTipi { get; set; }
        public YakitTuru YakitTuru { get; set; }
        public SanzimanTipi SanzimanTipi { get; set; }
        //public int MotorTipi { get; set; }
        //public int YakitTuru { get; set; }
        //public int SanzimanTipi { get; set; }
        [Range(1940,2024)]
        public short Yili { get; set; }
    }
}
