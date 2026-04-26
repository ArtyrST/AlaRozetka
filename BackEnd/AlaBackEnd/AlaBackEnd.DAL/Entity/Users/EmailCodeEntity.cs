using AlaBackEnd.DAL.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.Users
{
    public class EmailCodeEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Code {  get; set; } = string.Empty;
        public bool IsUsed { get; set; }
        public DateTime Timer { get; set; } = DateTime.Now;
        public int UsingCount { get; set; }
    }
}
