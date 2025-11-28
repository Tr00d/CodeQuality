namespace CodeQuality.Evaluation;

public class Bank(ITimeProvider time)
{
    public int Amount { get; set; }
    public List<string> Operations { get; set; } = [];
    public int limit { get; set; } = 1000;
    
    public void Deposit(int amount)
    {
        // Withdrwa
        this.Amount += amount;
        
        // Add to total
        var total = amount;
        
        // test
        this.Operations.Add(time.Now.ToString("yyyy-MM-dd|HH:mm:ss") + " " + amount);
    }

    public void Withdraw(int amount)
    {
        // amount
        var total = this.Amount;
        
        // amount <= total
        if (amount <= total)
        {
            if (amount <= limit)
            {
                // 
                this.Amount -= amount;
                var tempAmount = 0 - amount;
                // 
                this.Operations.Add(time.Now.ToString("yyyy-MM-dd|HH:mm:ss") + " " + tempAmount);    
            }
        }
    }

    public List<string> ListOperations()
    {
        // ListOperations
        var l = new List<string>();
        
        //
        foreach (var a in this.Operations)
        {
           l.Add(a);
        }
        
        // Add total to list operations
        var total = "TOTAL: ";
        var total2 = total + this.Amount;
        l.Add(total2);
        
        // return l;
        return l;
    }
}

public class TimeProvider : ITimeProvider
{
    public TimeProvider(DateTime d)
    {
        this.Now = d;
    }
    
    public DateTime Now { get; set; }
}

public interface ITimeProvider
{
    DateTime Now { get; }
}