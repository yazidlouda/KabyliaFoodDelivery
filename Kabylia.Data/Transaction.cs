﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kabylia.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfTransaction { get; set; }

        // public Customer Customer { get; set; }
        public Order Order { get; set; }
        // public Restaurant Restaurant { get; set; }

    }
}
