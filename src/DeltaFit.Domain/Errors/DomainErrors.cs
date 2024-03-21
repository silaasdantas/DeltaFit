using DeltaFit.Domain.Shared;

namespace DeltaFit.Domain.Errors
{
    public static class DomainErrors
    {
        public static class User
        {
            public static readonly Error EmailAlreadyInUse = new(
                "User.EmailAlreadyInUse",
                "The specified email is already in use");

            public static readonly Error PhoneAlreadyInUse = new(
               "User.PhoneAlreadyInUse",
               "The specified phone is already in use");

            public static readonly Func<Guid, Error> NotFound = id => new Error(
                "User.NotFound",
                $"The user with the identifier {id} was not found.");

            public static readonly Error NotExist = new Error(
                "User.NotExist",
                $"There is no users");

            public static readonly Error InvalidCredentials = new(
               "User.InvalidCredentials",
               "The provided credentials are invalid");
        }

        public static class Email
        {
            public static readonly Error Empty = new(
                "Email.Empty",
                "Email is empty");

            public static readonly Error InvalidFormat = new(
                "Email.InvalidFormat",
                "Email format is invalid");
        }

        public static class FirstName
        {
            public static readonly Error Empty = new(
                "FirstName.Empty",
                "First name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "FirstName name is too long");
        }

        public static class LastName
        {
            public static readonly Error Empty = new(
                "LastName.Empty",
                "Last name is empty");

            public static readonly Error TooLong = new(
                "LastName.TooLong",
                "Last name is too long");
        }

        public static class Phone
        {
            public static readonly Error Empty = new(
                "Phone.Empty",
                "Phone is empty");

            public static readonly Error InvalidFormat = new(
                "Phone.InvalidFormat",
                "Phone format is invalid");
        }

        public static class Password
        {
            public static readonly Error Empty = new(
                "Password.Empty",
                "Password is empty");

            public static readonly Error InvalidFormat = new(
                "Password.InvalidFormat",
                "Password format is invalid");
        }
    }
}
