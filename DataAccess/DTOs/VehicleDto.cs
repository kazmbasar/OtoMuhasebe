using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Plaka { get; set; }
        public string Model { get; set; }
        public string Müsteri_Adı { get; set; }
    }
}
