using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.Data_Access.Model
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Registration> SendingRegistrations { get; set; }
        public virtual ICollection<Registration> ReceivingRegistrations { get; set; }


    }
}
