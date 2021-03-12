using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountManangement
{
    public class AccountHolderRepository : BaseRepository
    {
        // how to create a new list
        public static List<AccountHolder> AccountHolders;

        public static AccountHolder LoggedInAccount;

        public AccountHolderRepository()
        {
            AccountHolders = new List<AccountHolder>();

            AccountHolders.Add(new AccountHolder(09, "Luqman", "Adeniji", "Olamide", "ade", "123", new DateTime(2000 / 2 / 3), "080693692", "Olomoore Abeokuta", "200890"));
        }


        public static void Read(int count, AccountHolder accountHolder)
        {
            Console.WriteLine($"{count}.\t{accountHolder.Id}\t{accountHolder.FirstName} {accountHolder.LastName} {accountHolder.MiddleName}\t{accountHolder.DateofBirth}\t{accountHolder.Email}\t{accountHolder.PhoneNumber}\t{accountHolder.Address}\t{accountHolder.Password}\t{accountHolder.AccountNumber}\t{accountHolder.AccountBalance}\t{accountHolder.AccountStatus}\t{accountHolder.Pin}\t{accountHolder.CreatedAt}");
        }


        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }

        public static void ListAccountHolders()
        {
            try
            {
                bool isEmpty = IsEmpty(AccountHolders);
                int count = 1;

                if (isEmpty)
                {
                    throw new Exception("No records found!");
                }

                foreach (AccountHolder accountHolder in AccountHolders)
                {
                    Read(count, accountHolder);
                    count++;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
        }

        public void CreateAccountHolder(int id, string firstName, string lastName, string middleName, DateTime dateOfBirth, string email, string phoneNumber, string address, string password, string checkPassword, string accountNumber)
        {
            AccountHolder accountHolder = new AccountHolder(id, firstName, lastName, middleName, email, password, dateOfBirth, phoneNumber, address, accountNumber);

            if (password == checkPassword)
            {
                var accountHolders = FindByIdOrEmail(id, email);

                if (accountHolders == null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Account Created Succesfully!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Your account number is: {accountNumber}");
                    AccountHolders.Add(accountHolder);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Account owner with this id {id} or email {email} already exists.");
                }
            }
            else
            {
                Console.WriteLine("Password did not match... Registration Failed");
            }

        }

        public static AccountHolder FindByIdOrEmail(int id = 0, string email = "")
        {
            return AccountHolders.Find(i => i.Id == id || i.Email == email);
        }

        public static AccountHolder FindByEmail(string email)
        {
            return AccountHolders.Find(i => i.Email == email);
        }

        public static AccountHolder FindById(int id)
        {
            return AccountHolders.Find(i => i.Id == id);
        }
        public static AccountHolder FindByAccountNumber(string accountNumber)
        {
            return AccountHolders.Find(i => i.AccountNumber == accountNumber);
        }

        public static void UpdateAccountHolder(int id, string firstName = "", string middleName = "", string lastName = "", string email = "", string address = "", string phoneNumber = "", int pin = 0, string status = "")
        {
            // var accountH = FindById(id);
            AccountHolder account = FindById(id);

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (firstName != "")
                {
                    account.FirstName = firstName;
                    Console.WriteLine($"You have succesfully updated the first name of id {account.Id}");
                }
                if (lastName != "")
                {
                    account.LastName = lastName;
                    Console.WriteLine($"You have succesfully updated the last name of id {account.Id}");

                }
                if (middleName != "")
                {
                    account.MiddleName = middleName;
                    Console.WriteLine($"You have succesfully updated the last name of id {account.Id}");

                }
                if (phoneNumber != "")
                {
                    account.PhoneNumber = phoneNumber;
                    Console.WriteLine($"You have succesfully updated the Phone Number  of id {account.Id}");

                }
                if (address != "")
                {
                    account.Address = address;
                    Console.WriteLine($"You have succesfully updated the address of id {account.Id}");

                }
                if (pin != 0)
                {
                    account.Pin = pin;
                    Console.WriteLine($"You have succesfully updated the pin of id {account.Id}");

                }
                if (status != "")
                {
                    int accStatus = 1;
                    if (status.Equals("active"))
                    {
                        accStatus = 1;
                    }
                    else if (status.Equals("inactive"))
                    {
                        accStatus = 0;
                    }
                    account.AccountStatus = accStatus;
                    Console.WriteLine($"You have succesfully updated the account status of id {account.Id}");

                }


            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        public static void RemoveAccountHolder(int id)
        {
            try
            {
                AccountHolder account = FindByIdOrEmail(id);

                if (account == null)
                {
                    throw new Exception("Account Not Found");
                }
                else
                {
                    Console.Write($"Are you sure you want to delete this account  with this Name - {account.FirstName} {account.LastName} {account.MiddleName}  (y/n): ");
                    string answer = Console.ReadLine();

                    if (answer.Equals("y"))
                    {
                        AccountHolders.Remove(FindByIdOrEmail(id));

                        Console.WriteLine($"User with id {id}  Deleted");

                    }
                    else
                    {
                        throw new Exception("Operation Cancelled");
                    }

                }


            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        public static int LoginAccountHolder(string userEmail)
        {

            try
            {
                bool isRightPassword = false;

                int tries = 3;

                string userPassword = string.Empty;


                bool recordIsEmpty = IsEmpty(AccountHolders);

                if (!recordIsEmpty)
                {
                    AccountHolder account = FindByEmail(userEmail);

                    if (account == null)
                    {
                        throw new Exception("Email not found!");
                    }
                    else
                    {

                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Enter your password: ");
                            userPassword = Console.ReadLine();

                            if (userPassword.Equals(account.Password))
                            {

                                if (account.AccountStatus == 0)
                                {
                                    throw new Exception("Your account is currently inactive. Please Contact an account manager.");
                                }
                                else
                                {
                                    Console.WriteLine($"Welcome {account.FirstName}");
                                    isRightPassword = true;
                                    LoggedInAccount = account;
                                    return account.Id;
                                }

                            }
                            else
                            {
                                if (tries > 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Invalid Password. You have {--tries} tries left");
                                    //--tries;
                                }
                                else
                                {
                                    throw new Exception("Account Locked. Contact Admin");
                                }
                            }

                        } while (!isRightPassword);
                        return 0;
                    }

                }
                else
                {
                    throw new Exception("No records found!");
                }

            }
            catch (Exception em)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {em.Message}");
                Menu.ShowContinueMenu();
                return 0;
            }

        }

        public static void LogOutAccountHolder()
        {
            LoggedInAccount = null;
        }

        public static void SaveMoney(bool isTransfer = false)
        {

            OverdraftManagement overdraftManagement = new OverdraftManagement();
            Console.Clear();
            Console.WriteLine("     ACCOUNT DEPOSIT MENU");
            Console.Write("How Much Do You Want To Save: ");

            double amountToSave = Convert.ToDouble(Console.ReadLine());

            overdraftManagement.PayOverdraft(LoggedInAccount, amountToSave);

            LoggedInAccount.AccountBalance += amountToSave;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have succesfully Deposited {amountToSave} into your account.");
            Console.WriteLine($"New Balance is {LoggedInAccount.AccountBalance}");
            Menu.ShowContinueMenu();
        }

        public static void WithdrawMoney()
        {
            Console.Clear();
            Console.WriteLine("     WITHDRAWAL MENU");

            if (LoggedInAccount.Pin == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dear Customer You Have To Change Your Pin First");
                SetPin();
            }
            else
            {
                Console.Write("Enter Your Pin: ");
                int userpin = Convert.ToInt32(Console.ReadLine());
                if (userpin.Equals(LoggedInAccount.Pin))
                {
                    Console.Write("How Much Do you Want To Withdraw: ");

                    double amountToWithdraw = Convert.ToDouble(Console.ReadLine());


                    if (LoggedInAccount.AccountBalance < amountToWithdraw)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insufficient Funds... Withdrawal Failed");
                        Menu.ShowContinueMenu();
                    }
                    else
                    {
                        LoggedInAccount.AccountBalance -= amountToWithdraw;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You have succesfully withdrawn {amountToWithdraw}");
                        Console.WriteLine($"Your Current Account Balance is {LoggedInAccount.AccountBalance}");
                        Menu.ShowContinueMenu();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Pin");
                    Menu.ShowContinueMenu();
                }
            }




        }

        public static void Transfer(string accountNumber, double amountToTransfer)
        {
            OverdraftManagement overdraftManagement = new OverdraftManagement();
            try
            {
                AccountHolder accountToTransferTo = FindByAccountNumber(accountNumber);

                if(accountNumber.Equals(LoggedInAccount.AccountNumber)){
                    throw new Exception("You cannot make a transfer to yourself");
                }

                if (accountToTransferTo == null)
                {
                    throw new Exception($"Account with account number {accountNumber} not does not exist. Please check and try again");
                }
                else
                {
                    if (LoggedInAccount.AccountBalance < amountToTransfer)
                    {
                        throw new Exception("Insufficient Balance.");
                    }
                    else
                    {
                        Console.Write($"Are you sure you want to transfer {amountToTransfer} to {accountToTransferTo.FirstName} {accountToTransferTo.LastName} (y/n): ");
                        string answer = Console.ReadLine().ToLower().Trim();
                        if (answer.Equals("y"))
                        {
                            if (LoggedInAccount.Pin == 0)
                            {
                                Console.WriteLine("You have to set your pin to continu..");
                                Menu.ShowContinueMenu();
                                ChangePin();
                            }
                            else
                            {
                                Console.Write("Enter your pin: ");
                                int enteredPin = Convert.ToInt32(Console.ReadLine());

                                if (enteredPin == LoggedInAccount.Pin)
                                {
                                    overdraftManagement.PayOverdraft(accountToTransferTo, amountToTransfer);
                                    accountToTransferTo.AccountBalance += amountToTransfer;
                                    LoggedInAccount.AccountBalance -= amountToTransfer;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Transfer Successful");
                                    Menu.ShowContinueMenu();
                                }
                                else{
                                    throw new Exception("Incorrect pin");
                                }
                            }

                        }
                        else if (answer.Equals("n"))
                        {
                            throw new Exception("Operation Cancelled.");
                        }
                        else
                        {
                            throw new Exception("Invalid input");
                        }

                    }
                }

            }
            catch (Exception e)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Menu.ShowContinueMenu();
            }
        }

        public static void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("     ACCOUNT BALANCE MENU");
            Console.WriteLine($"Your account Balance is {LoggedInAccount.AccountBalance}");
            Menu.ShowContinueMenu();
        }

        public static void SetPin()
        {
            Console.Clear();
            Console.WriteLine("     PIN UPDATE MENU");
            if (LoggedInAccount.Pin == 0)
            {
                ChangePin();
            }

            else
            {
                bool checkPassword = ConfirmAccountHolderPassword();
                if (checkPassword)
                {
                    ChangePin();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Password");
                    Menu.ShowContinueMenu();
                }

            }
        }

        public static void ChangePin()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Input your Desired Pin.... Please Note This Pin will be asked for authorizing transactions and it can only contain numbers.");
            int userpin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Confirm Your Pin: ");
            int confirmPin = Convert.ToInt32(Console.ReadLine());

            if (userpin.Equals(confirmPin))
            {
                LoggedInAccount.Pin = userpin;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congratulations dear {LoggedInAccount.FirstName} You have succesfully Set Your Pin");
                Menu.ShowContinueMenu();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pin doesn't match");
                Menu.ShowContinueMenu();
            }
        }

        public static void ChangePassword()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("     PASSWPRD UPDATE MENU");
                bool checkPassword = ConfirmAccountHolderPassword(true);
                if (!checkPassword)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("Password Update Failed Due To Wrong Old Password");
                }
                else
                {
                    Console.Write("Enter Your New Password: ");
                    string newPassword = Console.ReadLine();
                    Console.Write("Confirm Your New Password: ");
                    string confirmNewPassword = Console.ReadLine();

                    if (newPassword != confirmNewPassword)
                    {

                        throw new Exception("Password Update Failed...Password Did Not Match");
                    }
                    else
                    {
                        LoggedInAccount.Password = newPassword;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Password Changed Successfully");

                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);


            }
            finally
            {
                Menu.ShowContinueMenu();
            }
        }

        public static bool ConfirmAccountHolderPassword(bool isChangePassword = false)
        {
            if (isChangePassword)
            {
                Console.Write("Enter Old Password: ");
            }

            else
            {
                Console.Write("Enter Your Password: ");
            }

            string password = Console.ReadLine();
            return password.Equals(LoggedInAccount.Password);
        }


    }

}
