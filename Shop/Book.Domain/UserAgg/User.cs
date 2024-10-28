using Book.Domain.UserAgg.Enum;
using Book.Domain.UserAgg.Services;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Book.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User() { }

        public User(string name, string family, string phoneNumber, string email, string password, Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserRole> Roles { get; protected set; }

        public void EditUser(string name, string family, string phoneNumber, string email, string password, Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;

        }

        public static User RegisterUser(string phoneNumber, string email, string password, IDomainUserService domainService)
        {

            return new User("", "", phoneNumber, email, password, Gender.None, domainService);
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == address.UserId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("address Not Found");

            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void RemoveAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("address not found");

            Addresses.Remove(oldAddress);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRole(List<UserRole> roles)
        {
            roles.ForEach(r => r.UserId = Id);

            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber, string email, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (domainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");

        }
    }
}
