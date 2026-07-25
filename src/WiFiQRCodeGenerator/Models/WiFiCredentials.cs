namespace WifiQRCodeGenerator.Models;

public record WiFiCredentials(string Name, string Password, AuthType Auth = AuthType.WPA2);