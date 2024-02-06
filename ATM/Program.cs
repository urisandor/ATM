using System;

public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }


    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
     
    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How mich $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.balance}");

        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How mich $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if(currentUser.getBalance() < withdrawal) 
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you");
            }
        }
        void balance(CardHolder currentUser)
        {
            Console.WriteLine($"Current balance: {currentUser.getBalance()}");
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("1234567890987654", 1234, "Peter", "Griffin", 1502.47));
        cardHolders.Add(new CardHolder("1098765432174734", 4321, "Lois", "Griffin", 152.28));
        cardHolders.Add(new CardHolder("3247289579843755", 2468, "Chris", "Griffin", 47.78));
        cardHolders.Add(new CardHolder("8754385709324758", 8642, "Mag", "Griffin", 37.30));
        cardHolders.Add(new CardHolder("6478298237462992", 3719, "Stewie", "Griffin", 5730.68));
        cardHolders.Add(new CardHolder("1349905783475002", 6969, "Brian", "Griffin", 2659.56));

        //Promp user
        Console.WriteLine("Welcome to GriffinATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        CardHolder currentUser;


        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }

        Console.WriteLine($"Welcome {currentUser.getFirstName()}");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }                    
        }
        while(option != 4);       
        Console.WriteLine("Thank you! Have a nice Day!");
        
    }
}