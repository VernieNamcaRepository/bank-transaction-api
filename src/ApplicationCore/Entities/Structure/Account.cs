using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace BankTransaction.ApplicationCore.Entities.Structure
{
    public class Account : BaseEntity<int>
    {
        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public decimal CurrentBalance { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }
    }
}
