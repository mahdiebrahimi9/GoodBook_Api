using Common.Domain;
using Common.Domain.Exceptions;
using System.Security.Authentication;

namespace Book.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(string shire, string city, string postalCode, string name, string family, string postalAddress, string phoneNumber, string nationalCode)
        {
            Guard(shire, city, postalCode, name, family, postalAddress, phoneNumber, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Name = name;
            Family = family;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            ActiveAddress = false;
        }
        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public bool ActiveAddress { get; private set; }

        public void Edit(string shire, string city, string postalCode, string name, string family, string postalAddress, string phoneNumber, string nationalCode)
        {
            Guard(shire, city, postalCode, name, family, postalAddress, phoneNumber, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Name = name;
            Family = family;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;

        }

        public void SetActive()
        {
            ActiveAddress = true;
        }

        public void Guard(string shire, string city, string postalCode, string name, string family, string postalAddress, string phoneNumber, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }

}
