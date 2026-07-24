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
            var name = AnsiConsole.Prompt(new TextPrompt<string>("[white]Enter WiFi name:[/]").Validate(value => !string.IsNullOrWhiteSpace(value), "WiFi name cannot be empty."));
            var password = AnsiConsole.Prompt(new TextPrompt<string>("[white]Enter WiFi password:[/]").Validate(value => !string.IsNullOrWhiteSpace(value), "WiFi password cannot be empty."));
            var auth = AnsiConsole.Prompt(new TextPrompt<string>("Enter auth type (WPA2, WPA, WEP, nopass) - press enter to skip:")
                .DefaultValue("WPA2")
                .AllowEmpty());

            var credentials = new WiFiCredentials(name, password, auth);
            var qrBytes = QrCodeService.Generate(credentials);
            QrImageRenderer.Render(qrBytes, credentials);
            AnsiConsole.MarkupLine($"[green]✓[/] QR code generated");
            AnsiConsole.MarkupLine($"[blue]{Directory.GetCurrentDirectory()}[/]");
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

        Option<string> authOption = new("--auth", "-a")
        {
            Description = "Authentication type (WPA2, WPA, WEP, nopass)",
            DefaultValueFactory = _ => "WPA2"
        };

        rootCommand.Options.Add(nameOption);
        rootCommand.Options.Add(passwordOption);
        rootCommand.Options.Add(authOption);
        
        rootCommand.SetAction(parseResult =>
        {
            string? name = parseResult.GetValue(nameOption);
            string? password = parseResult.GetValue(passwordOption);
            string? auth = parseResult.GetValue(authOption);

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password is required.");
                return;
            }

            var credentials = new WiFiCredentials(name!, password!, auth!);

            var qrBytes = QrCodeService.Generate(credentials);

            QrImageRenderer.Render(qrBytes, credentials);

            Console.WriteLine($"Name: {name}\nPassword: {password}\nAuth: {auth}");
        });

        return rootCommand.Parse(args).Invoke();
    }
}