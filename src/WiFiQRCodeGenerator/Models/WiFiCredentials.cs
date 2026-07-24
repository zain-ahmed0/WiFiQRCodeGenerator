namespace WifiQRCodeGenerator.Models;

public record WiFiCredentials(string Name, string Password, string Auth = "WPA2");