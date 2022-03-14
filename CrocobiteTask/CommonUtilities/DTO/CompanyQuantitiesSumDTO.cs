using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.CommonUtilities.DTO
{
    public class CompanyQuantitiesSumDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalSumOfQuantities { get; set; }
        public int SumOfSendingQuantity { get; set; }
        public int SumOfReceivingQuantity { get; set; }
    }
}
