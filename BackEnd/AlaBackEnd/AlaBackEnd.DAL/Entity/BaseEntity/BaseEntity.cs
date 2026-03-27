using System;
using System.Collections.Generic;
using System.Text;

namespace AlaBackEnd.DAL.Entity.BaseEntity
{
    public interface IBaseEntity
    {
        public int ID { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        public int ID {  set; get; }
    }
}
