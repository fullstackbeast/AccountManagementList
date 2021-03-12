using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangement
{
   public class OverDraft
   {
       private int _id;
       private int _accountHolderId;
       private double _amount;
       private double _amountLeft;
       private string _status;
       private string _overdraftDate;


        public OverDraft(int id, AccountHolder accountHolder, double amount, string status = "active")
        {
            _id = id;
            _accountHolderId = accountHolder.Id;
            _amount = amount;
            _overdraftDate = DateTime.Now.ToString("yyyy/MM/dd");
            _status = status;
            _amountLeft = amount - accountHolder.AccountBalance;
        }

        public int Id{
            get{return _id;}
            set{_id = value;}
        }
        public int AccountHolderId{
            get{return _accountHolderId;}
            set{_accountHolderId = value;}
        }

        public double Amount {
            get{return _amount;}
            set{_amount = value;}
        }

         public string Status
        {
            get {return _status;}
            set{_status = value;}
        }

        public double AmountLeft
        {
            get {return _amountLeft;}
            set{_amountLeft = value;}
        } 

        public string OverdraftDate{
            get{ return _overdraftDate;}
            set{_overdraftDate = value;}
        }
    }
}
