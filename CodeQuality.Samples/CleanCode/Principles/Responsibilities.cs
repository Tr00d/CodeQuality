namespace CodeQuality.Samples.CleanCode.Principles;

public class Message(string userName, string toto)
{
    public string UserName { get; } = userName;
    public string Toto { get; } = toto;
}

public class NotificationService
{
    public List<string> Logs { get; set; } = new();
    public List<Customer> Users { get; set; } = new();

    public void ExportLogsToCsv()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "logs.csv");
        File.WriteAllLines(path, Logs);
        Console.WriteLine($"Logs exported to {path}");
    }

    public void RegisterUser(string name, string email, string phone, string preference)
    {
        var user = new Customer
        {
            Name = name,
            Email = email,
            Phone = phone,
            ContactPreference = preference,
            CreatedAt = DateTime.Now
        };

        Users.Add(user);
        Logs.Add($"[{DateTime.Now}] User registered: {name}");
    }

    public void SendMessage(Message message)
    {
        var user = Users.FirstOrDefault(u => u.Name == message.UserName);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        if (user.ContactPreference == "Email")
        {
            this.Smtp(message.Toto, user);
        }
        else if (user.IsSmsContactPreference())
        {
            this.Sms(message.Toto, user);
        }
        else
        {
            Unknown();
        }
    }

    private static void Unknown()
    {
        Console.WriteLine("Unknown contact preference");
    }

    private void Sms(string message, Customer user)
    {
        var gateway = new SmsGateway();
        gateway.SendSms(user.Phone, message);
        this.Logs.Add($"[{DateTime.Now}] SMS sent to {user.Phone}");
    }

    private void Smtp(string message, Customer user)
    {
        var smtp = new SmtpClient();
        smtp.Send("noreply@company.com", user.Email, "Notification", message);
        this.Logs.Add($"[{DateTime.Now}] Email sent to {user.Email}");
    }
}

public class Customer
{
    public string ContactPreference { get; set; }
    public DateTime CreatedAt{ get; set; }
    public string Email{ get; set; }
    public string Name{ get; set; }
    public string Phone{ get; set; }

    public bool IsSmsContactPreference() => this.ContactPreference == "Sms";
}

public class SmtpClient
{
    public void Send(string from, string to, string subject, string body) => Console.WriteLine($"SMTP {subject} to {to}");
}

public class SmsGateway
{
    public void SendSms(string phone, string message) => Console.WriteLine($"SMS → {phone}: {message}");
}

public class ResponsibilitiesTest
{
    [Fact]
    public void yolo()
    {
        var a = new NotificationService();
        a.SendMessage(new Message("test", "test2"));
    }
}