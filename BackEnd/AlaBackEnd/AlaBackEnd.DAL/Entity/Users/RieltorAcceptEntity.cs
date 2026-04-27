using AlaBackEnd.DAL.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Users
{
    public class RieltorAcceptEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
