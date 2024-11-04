public class Client
{
    private string name;
    private string passport;
    private string birthDate;
    private string phoneNubmer;
    private List<BankAccaunt> accauntList;
    private List<Transaction> transactionList;

    public void createTransaction(IPayment sender, IPayment receiver, double amount) 
    {
        Transaction transaction = new Transaction();
        transaction.transaction(sender, receiver, amount);
        transactionList.Add(transaction);
    }
    public void createAccount(string type, string currency) { }
    public void createCard(BankAccaunt accaunt) 
    {
        accaunt.createCard();
    }
}


public class Employee : Client
{
    private string position;
    private double wage;
    private string address;

    public bool approve(Service service) { }
}


interface IPayment
{
    void pay(IPayment receiver, double amount);
    void receive(double amount);
    void block(IPayment payment);
}


public class BankAccount : IPayment
{
    private string number;
    private string type;
    private double balance;
    private string currency;
    private bool available;
    private List<Card> cards;

    public double getBalance()
    {
        return this.balance;
    }
    public void setBalance(double newBalance)
    {
        this.balance = newBalance;
    }
    public Card createCard() 
    {
        if(available == true)
        {
            Card card = new Card();
            cards.Add(card);
            return card;
        }
    }
    void pay(IPayment receiver, double amount) 
    {
        balance -= amount;
        receiver.receive(amount);
    }
    void receive(double amount)
    {
        balance += amount;
    }
    void block(IPayment payment) { }
}


public class Card : IPayment
{
    private string number;
    private string expDate;
    private string verificationCode;
    private string owner;
    private string pinCode;
    private bool available;

    public void changePinCode() { }
    void pay(IPayment receiver, double amount) 
    {

    }
    void block(IPayment payment) { }
}


public class Transaction
{
    private IPayment sender;
    private IPayment receiver;
    private double amount;
    private bool successful;
    private string date;
    
    public void transaction(IPayment sender, IPayment receiver, double amount) 
    {
        bool result = checkTransaction();
        if(result == true)
        {
            sender.pay(receiver, amount);
        }
    }
    public bool checkTransaction() { }
}


public class Service
{
    private string date;

    public bool sendToEmp() 
    {
        ///
        Employee employee = new Employee();
        ///
        bool check = employee.approve(this);
        return check;
    }
    public static Result credit() 
    {
        bool check = sendToEmp();
        if (check == true)
        {
            return Result.GetResult(this);
        }
    }
    public static Result mortgage() { }
}


public class Result
{
    private string document;
    private bool successful;

    public static Result GetResult(Service service) { }
}