public class Client
{
    private string name;
    private string passport;
    private string birthDate;
    private string phoneNubmer;
    private List<Bankaccount> accountList;
    private List<Transaction> transactionList;

    public void createTransaction(IPayment sender, IPayment receiver, double amount) 
    {
        Transaction transaction = new Transaction();
        transaction.transaction(sender, receiver, amount);
        transactionList.Add(transaction);
    }
    public void createAccount(string type, string currency) { }
    public void createCard(Bankaccount account) 
    {
        account.createCard();
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
    void pay(double amount);
    void receive(double amount);
    void block(IPayment payment);
}


public class BankAccount : IPayment
{
    private string number;
    private string type;
    private double balance;
    private string currency;
    private bool ilable;
    private List<Card> cards;
    
    public bool isAvailable()
    {
        return available;
    }
    public double getBalance()
    {
        return this.balance;
    }
    public void setBalance(double newBalance)
    {
        this.balance = newBalance;
    }
    public createCard() 
    {
        if(ilable == true)
        {
            Card card = new Card(this);
            cards.Add(card);
            return card;
        }
    }
    void pay(double amount) 
    {
        balance -= amount;
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
    private BankAccount account;

    public Card(BankAccount account){
        this.account = account;
    }
    public void changePinCode() { }
    void pay(double amount){ }
    void receive(double amount){ }
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
            sender.pay(amount);
            receiver.receive(amount);
            successful = true;
        }
    }
    public bool checkTransaction() { }
}


public class Service
{
    private string date;
    private Client client;
    private Employee employee;

    public Service(Client client){
        this.client = client;
    }
    public bool sendToEmp() 
    {
        ///
        Employee employee = new Employee();
        ///
        bool check = employee.approve(this);
        return check;
    }
    public static Result credit(Client client) 
    {
        Service service = new Service();
        bool check = sendToEmp(service);
        if (check == true)
        {
            return Result.GetResult(service);
        }
    }
    public static Result mortgage(Client client) { }
}


public class Result
{
    private string document;
    private bool successful;
    private Client client;
    private Service service;

    public Result(Client client, Service service, bool success) { 
        ///
        Result result = new Result();
        this.successful = success;
        this.client = client;
        this.service = service;
        return result;
    }
}
