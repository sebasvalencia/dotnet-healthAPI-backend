using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Diagnostic { get; set; }
        public string Treatment { get; set; }
        
        [Column(TypeName = "Date")]
        public DateTime AppointmentDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
