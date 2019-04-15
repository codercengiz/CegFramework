using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegFramework.Core.Entities;

namespace CegFramework.Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }    
        public virtual string Description { get; set; }    
        public virtual Byte[] Picture { get; set; }    


    }
}
