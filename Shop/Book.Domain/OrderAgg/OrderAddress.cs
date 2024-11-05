using Common.Domain;

namespace Book.Domain.OrderAgg
{
    public class OrderAddress : BaseEntity
    {
        public OrderAddress(string shire, string city, string postalCode, string name, string family
            , string postalAddress, string phoneNumber, string nationalCode)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Name = name;
            Family = family;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;

        }
        public long OrderId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public Order Order { get; private set; }
    }

}