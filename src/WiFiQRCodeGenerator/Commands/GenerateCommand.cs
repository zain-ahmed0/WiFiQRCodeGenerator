using System.CommandLine;
using Spectre.Console;
using WifiQRCodeGenerator.Models;
using WifiQRCodeGenerator.Services;

namespace WifiQRCodeGenerator.Commands;

public static class GenerateCommand
{
    public static int Run(string[] args)
    {
        if (args.Length == 0)
        {
            var name = AnsiConsole.Prompt(new TextPrompt<string>("Enter WiFi name:").Validate(value => !string.IsNullOrWhiteSpace(value), "WiFi name cannot be empty."));
            var password = AnsiConsole.Prompt(new TextPrompt<string>("Enter WiFi password:").Validate(value => !string.IsNullOrWhiteSpace(value), "WiFi password cannot be empty."));

            var credentials = new WiFiCredentials(name!, password!);
            var qrBytes = QrCodeService.Generate(credentials);
            QrImageRenderer.Render(qrBytes, credentials);
            return 0;
        }

        RootCommand rootCommand = new("Generate a QR code for your WiFi network");

        Option<string> nameOption = new("--name", "-n")
        {
            Description = "Name",
        };

        Option<string> passwordOption = new("--password", "-p")
        {
            Description = "Password",
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

            Console.WriteLine($"Name: {name}\nPassword: {password}");
        });

        return rootCommand.Parse(args).Invoke();
    }
}