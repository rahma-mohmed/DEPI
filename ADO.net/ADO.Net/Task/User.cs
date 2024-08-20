namespace Task
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Status { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int CountryID { get; set; }
        public DateTime CreatedAt {  get; set; }


        public User()
        {

        }
        public User(int _userID , string _userName , string _email , string _passwordHash , string _status,
            string _addressLine1 , string _addressLine2 , string _city , string _state,
            string _postalCode , int _countryID , DateTime _createdAt)
        {
            UserID = _userID;
            UserName = _userName;
            Email = _email;
            PasswordHash = _passwordHash;
            Status = _status;
            AddressLine1 = _addressLine1;
            AddressLine2 = _addressLine2;
            City = _city;
            State = _state;
            PostalCode = _postalCode;
            CountryID = _countryID;
            CreatedAt = _createdAt;
        }
    }
}

