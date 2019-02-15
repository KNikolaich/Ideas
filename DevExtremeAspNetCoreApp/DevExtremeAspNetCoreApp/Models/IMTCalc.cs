using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreApp.Models
{
    [DisplayName("Индекс массы тела")]
    public class ImtCalc
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [DisplayName("Вес")]
        public double Weight { get; set; }

        [DisplayName("Рост")]
        public double Height { get; set; }

        [ScaffoldColumn(false), HiddenInput(DisplayValue = false)]
        public DateTime DateCalculate { get; set; }

    }
}
