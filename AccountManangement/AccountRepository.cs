using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManangement
{
    public class AccountRepository
    {
        public List<Account> Accounts;

        public AccountRepository()
        {
            Accounts = new List<Account>();
        }

        public void Read(Account account)
        {
            Console.WriteLine("");
        }
        
    }
   

    
}
