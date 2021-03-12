using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangement
{
   public class Loan
    {
        private int _id;
        private int _accountHolderId;
        private string _status;
        private string _loanType;
        private string _dateOfLoan;
        private double _amount;
        private double _amountLeft;

        public Loan(int id, int accountHolderId, string loanType, double amount, string status="active")
        {
            _id = id;
            _accountHolderId = accountHolderId;
            _status = status;
            _loanType = loanType;
            _dateOfLoan = DateTime.Now.ToString("yyyy/MM/dd");
            _amount = amount;
            _amountLeft = amount;
        }

        public int Id
        {
            get{return _id;}
            set{_id = value;}
        }

        public int AccountHolderId{
            get{return _accountHolderId;}
            set {_accountHolderId = value;}
        }

        public string Status
        {
            get {return _status;}
            set{_status = value;}
        }
        public string LoanType
        {
            get {return _loanType;}
            set{_loanType = value;}
        }
        public string DateOfLoan
        {
            get {return _dateOfLoan;}
            set{_dateOfLoan = value;}
        }
        public double Amount
        {
            get {return _amount;}
            set{_amount = value;}
        } 
        public double AmountLeft
        {
            get {return _amountLeft;}
            set{_amountLeft = value;}
        } 

    }
}
