using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.CommonUtilities.DTO
{
    public class RegisterationDTO
    {
        public Guid SendingCompanyID { get; set; }
        public Guid ReceivingCompanyID { get; set; }
        public int Quantity { get; set; }
    }
}
