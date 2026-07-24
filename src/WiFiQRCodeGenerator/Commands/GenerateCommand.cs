using System.CommandLine;
using WifiQRCodeGenerator.Services;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Commands;

public static class GenerateCommand
{
    public static int Run(string[] args)
    {
        RootCommand rootCommand = new("Generate a QR code for your WiFi network");

        Option<string> nameOption = new("--name", "-n")
        {
            Description = "Name",
            Required = true
        };
        
        Option<string> passwordOption = new("--password", "-p")
        {
            Description = "Password",
            Required = true
        };
        
        rootCommand.Options.Add(nameOption);
        rootCommand.Options.Add(passwordOption);
        
        rootCommand.SetAction(parseResult =>
        {
            string? name = parseResult.GetValue(nameOption);
            string? password = parseResult.GetValue(passwordOption);
            
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("WiFi Name and Password are required.");
                return;
            }

            var credentials = new WiFiCredentials(name!, password!);

            var qrBytes = QrCodeService.Generate(credentials);
            
            QrImageRenderer.Render(qrBytes, credentials);
            
            Console.WriteLine($"Name: {name}\nPassword: {password}" );
        });
        
        return rootCommand.Parse(args).Invoke();
    }
}