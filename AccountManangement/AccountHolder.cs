using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangement
{
    public class AccountHolder : Details
    {
        private string _dateOfBirth;

        private string _phoneNumber;

        private string _address;

        private string _accountNumber;

        private double _accountBalance;

        private int _accountStatus;

        private int _pin;

        private string _createdAt;

        public AccountHolder(int id, string firstName, string lastName, string middleName, string email, string password, DateTime dateOfBirth, string phoneNumber, string address, string accountNumber, double accountBalance = 0.00, int accountStatus = 1, int pin = 0) : base(id, firstName, lastName, middleName, email, password)
        {
            _dateOfBirth = dateOfBirth.ToShortDateString();

            _phoneNumber = phoneNumber;

            _address = address;

            _accountNumber = accountNumber;

            _accountBalance = accountBalance;

            _accountStatus = accountStatus;

            _pin = pin;

            _createdAt = DateTime.Now.ToString("yyyy/MM/dd");;
        }

        public string DateofBirth
        {
            get { return _dateOfBirth;  }
            set { _dateOfBirth = value;  }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public double AccountBalance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; }
        }
        public int AccountStatus
        {
            get { return _accountStatus; }
            set { _accountStatus = value; }
        }

        public int Pin
        {
            get { return _pin; }
            set { _pin = value; }
        }

        public string CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }
    }

}
