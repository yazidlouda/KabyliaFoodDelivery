using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kabylia.Data;
namespace Kabylia.Models.Transaction
{
    public class TransactionCreate
    {
        //public int TransactionId { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public int OrderId { get; set; }
        //public virtual Order Order { get; set; }
    }
}
