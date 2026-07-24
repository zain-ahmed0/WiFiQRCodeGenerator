namespace WifiQRCodeGenerator.Models;

public class WiFiCredentials(string name, string password)
{
    public string? Name { get; set; }
    
    public string? Password { get; set; }
}