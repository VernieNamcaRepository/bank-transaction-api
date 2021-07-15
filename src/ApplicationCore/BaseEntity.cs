using System.Runtime.Serialization;

namespace BankTransaction.ApplicationCore
{
    [DataContract]
    public class BaseEntity<IdType>
    {
        //[DataMember(IsRequired = false)]
        //public IdType Id { get; set; }
    }
}
