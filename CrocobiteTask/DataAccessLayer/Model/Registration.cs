using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.Data_Access.Model
{
    public class Registration
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SendingCompanyID { get; set; }
        public Guid ReceivingCompanyID { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public Company SendingCompany { get; set; }
        public Company ReceivingCompany { get; set; }


    }
}
