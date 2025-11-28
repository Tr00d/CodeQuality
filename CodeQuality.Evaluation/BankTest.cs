namespace CodeQuality.Evaluation;

public class BankTest
{
    [Fact]
    public void depo()
    {
        // Arrange
        var b = new Bank(new TimeProvider(DateTime.Now));
        b.Deposit(100);
        // Act
        var a = b.ListOperations();
        // Assert
        Assert.True(a.Count == 2);
    }
    
    [Fact]
    public void depo2()
    {
        // Arrange
        var b = new Bank(new TimeProvider(new DateTime(2020, 01, 30, 10, 0, 0)));
        // Act
        b.Deposit(100);
        var a = b.ListOperations();
        Assert.Equal("2020-01-30|10:00:00 100", a[0]);
        //Assert
        Assert.Equal("TOTAL: 100", a[1]);
    }
    
    [Fact]
    public void w()
    {
        // Arrange
        var b = new Bank(new TimeProvider(DateTime.Now));
        b.Deposit(100);
        // Act
        b.Withdraw(100);
        var a = b.ListOperations();
        // Assert
        Assert.True(a.Count == 3);
    }
    
    [Fact]
    public void ww()
    {
        // Arrange
        var t = new TimeProvider(new DateTime(2020, 01, 30, 10, 0, 0));
        var b = new Bank(t);
        b.Deposit(100);
        t.Now = new DateTime(2020, 01, 31, 11, 0, 0);
        b.Withdraw(100);
        // Act
        var a = b.ListOperations();
        // Assert
        Assert.Equal("2020-01-30|10:00:00 100", a[0]);
        Assert.Equal("2020-01-31|11:00:00 -100", a[1]);
        Assert.Equal("TOTAL: 0", a[2]);
    }
    
    [Fact]
    public void wzero()
    {
        // Arrange
        var b = new Bank(new TimeProvider(DateTime.Now));
        b.Withdraw(100);
        // Act
        var a = b.ListOperations();
        // Assert
        Assert.True(a.Count == 1);
        Assert.Equal("TOTAL: 0", a[0]);
    }
    
    [Fact]
    public void l()
    {
        // Arrange
        var b = new Bank(new TimeProvider(DateTime.Now));
        b.Deposit(1500);
        b.Withdraw(1001);
        // Act
        var a = b.ListOperations();
        // Assert
        Assert.True(a.Count == 2);
    }

    [Fact]
    public void test()
    {
        var t = new TimeProvider(new DateTime(2020, 01, 30, 10, 0, 0));
        var b = new Bank(t);
        b.Deposit(100);
        b.Withdraw(10);
        b.Deposit(20);
        b.Deposit(50);
        b.Withdraw(30);
        b.Withdraw(90);
        b.Withdraw(40);
        b.Withdraw(1);
    }
}