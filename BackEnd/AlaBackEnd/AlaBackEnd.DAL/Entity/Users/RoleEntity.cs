using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Users
{
    public class RoleEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        //relation with user
        public virtual List<UserEntity> Users { get; set; } = [];
    }
}
