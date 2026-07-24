using System.CommandLine;
using Spectre.Console;
using WifiQRCodeGenerator.Models;
using WifiQRCodeGenerator.Services;

namespace WifiQRCodeGenerator.Commands;

public static class GenerateCommand
{
    private static readonly HashSet<string> ValidAuthTypes = ["WPA2", "WPA", "WEP", "NOPASS"];

    public static int Run(string[] args)
    {
        if (args.Length == 0)
        {
            var name = AnsiConsole.Prompt(
                new TextPrompt<string>("[white]Enter WiFi name:[/]").Validate(
                    value => !string.IsNullOrWhiteSpace(value), "[red]WiFi name cannot be empty.[/]"));
            var password =
                AnsiConsole.Prompt(new TextPrompt<string>("[white]Enter WiFi password:[/]").Validate(
                    value => !string.IsNullOrWhiteSpace(value), "[red]WiFi password cannot be empty.[/]"));
            var auth = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select auth type:")
                    .AddChoices("WPA2", "WPA", "WEP", "nopass")
                    .UseConverter(choice => choice == "WPA2" ? "WPA2 (Default)" : choice));

            var credentials = new WiFiCredentials(name, password, auth);

            return GenerateAndOutput(credentials);
        }

        RootCommand rootCommand =
            new("Generates a scannable QR code image for your WiFi network, saved as a PNG to the current directory");

        Option<string> nameOption = new("--name", "-n")
        {
            Description = "The (name) of the WiFi network as it appears when scanning for networks",
        };

        Option<string> passwordOption = new("--password", "-p")
        {
            Description =
                "The security protocol used by the network. WPA2 is recommended for most modern routers (default: WPA2)",
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
                AnsiConsole.MarkupLine("[red]Name is required.[/]");
                return 1;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                AnsiConsole.MarkupLine("[red]Password is required.[/]");
                return 1;
            }

            if (auth is null || !ValidAuthTypes.Contains(auth.ToUpper()))
            {
                AnsiConsole.MarkupLine(
                    $"[red]Invalid auth type '[/]{auth}[red]'. Must be one of: WPA2, WPA, WEP, nopass[/]");
                return 1;
            }

            var credentials = new WiFiCredentials(name, password, auth);

            return GenerateAndOutput(credentials);
        });

        return rootCommand.Parse(args).Invoke();
    }

    private static int GenerateAndOutput(WiFiCredentials credentials)
    {
        try
        {
            var qrBytes = QrCodeService.Generate(credentials);
            QrImageRenderer.Render(qrBytes, credentials);
            AnsiConsole.MarkupLine("[green]✓[/] QR code generated");
            AnsiConsole.MarkupLine($"[blue]{Directory.GetCurrentDirectory()}[/]");
            return 0;
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
            return 1;
        }
    }
}