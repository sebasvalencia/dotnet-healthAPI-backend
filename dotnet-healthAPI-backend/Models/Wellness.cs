using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Models
{
    public class Wellness
    {
		public int Id { get; set; }
		public bool checkBasketball { get; set; }
		public bool checkSwimming { get; set; }
		public bool checkRunning { get; set; }
		public bool checkRugby { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
