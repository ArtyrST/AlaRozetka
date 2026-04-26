using AlaBackEnd.DAL.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Users
{
    public class PandingUserEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string Login {  get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string password { get; set;  } = string.Empty;
        public DateTime CreateTime { get; set; }
    }
}
