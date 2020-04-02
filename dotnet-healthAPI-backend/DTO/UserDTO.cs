using dotnet_healthAPI_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.DTO
{
    public class UserDTO
    {
 
        public UserDTO(int idUser, string nameUser, string avatarUrl, int rol)
        {
            Id = idUser;
            Name = nameUser;
            AvatarUrl = avatarUrl;
            Rol = rol;
        }

        public UserDTO() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public int Rol { get; set; }
        public List<SicknessDTO> ListSickness { get; set; }
    }
}
