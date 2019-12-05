using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerApp.Models
{

    public class CarsRoot
    {
        public Cars[] Property1 { get; set; }
    }

    public class Cars
    {
        public int carId { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
    }


}
