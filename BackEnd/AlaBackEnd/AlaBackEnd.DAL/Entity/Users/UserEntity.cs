using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Users
{
    public class UserEntity
    {
        public int Id { get;set; }
        public required string Email { get;set; }  
        public required string FirstName { get;set; } 
        public string LastName { get; set; } = string.Empty;

        //Relation with role
        public virtual List<RoleEntity> Roles { get; set; } = [];

    }
}
