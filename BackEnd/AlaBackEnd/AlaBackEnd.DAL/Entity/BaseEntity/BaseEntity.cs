using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.BaseEntity
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public int Id {  set; get; }
    }
}
