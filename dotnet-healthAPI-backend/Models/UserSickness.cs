using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Models
{
    public class UserSickness
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SicknessId { get; set; }

        //Relationships
        public User User { get; set; }
        public Sickness Sickness { get; set; }
    }
}
