using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "A maximum of 150 characters allowed for brand.")]
        public string Brand { get; set; }

        [StringLength(30, ErrorMessage = "A maximum of 30 characters allowed for power.")]
        public string Power { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters allowed for cooling.")]
        public string Cooling { get; set; }

        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed for carburetor.")]
        public string Carburetor { get; set; }

        [StringLength(50, ErrorMessage = "A maximum of 50 characters allowed for engine model.")]
        public string EngineModel { get; set; }

        [StringLength(30, ErrorMessage = "A maximum of 30 characters allowed for model number")]
        public string ModelNumber { get; set; }

        [StringLength(10, ErrorMessage = "A maximum of 10 characters allowed for displacement.")]
        public string Displacement { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters allowed for fuel")]
        public string Fuel { get; set; }

        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed for fuel pump.")]
        public string FuelPump { get; set; }

        [StringLength(70, ErrorMessage = "A maximum of 70 characters allowed for oil pump.")]
        public string OilPump { get; set; }

        [StringLength(75, ErrorMessage = "A maximum of 75 characters allowed for starter.")]
        public string Starter { get; set; }

        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed for belts.")]
        public string Belts { get; set; }

        [StringLength(60, ErrorMessage = "A maximum of 60 characters allowed for cylinders.")]
        public string Cylinders { get; set; }

        [StringLength(100, ErrorMessage = "A maximum of 100 characters allowed for governor.")]
        public string Governor { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters allowed for idle speed.")]
        public string IdleSpeed { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters allowed for battery.")]
        public string Battery { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters allowed for battery charging.")]
        public string BatteryCharging { get; set; }

        [StringLength(20, ErrorMessage = "A maximum of 20 characters allowed for  battery charging output.")]
        public string BatteryChargingOutput { get; set; }

        [StringLength(40, ErrorMessage = "A maximum of 40 characters allowed for fuses.")]
        public string Fuses { get; set; }
    }
}
