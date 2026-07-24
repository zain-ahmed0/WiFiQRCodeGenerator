using SkiaSharp;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Services;

public static class QrImageRenderer
{
    public static void Render(byte[] qrBytes, WiFiCredentials credentials)
    {
        using var qrBitmap = SKBitmap.Decode(qrBytes);

        int padding = 50;
        int textHeight = 120;
        int canvasWidth = qrBitmap.Width + padding * 2;
        int canvasHeight = qrBitmap.Height + padding * 2 + textHeight;
        
        using var bitmap = new SKBitmap(canvasWidth, canvasHeight);
        using var canvas = new SKCanvas(bitmap);
        
        canvas.Clear(SKColors.White);
        canvas.DrawBitmap(qrBitmap, new SKPoint(padding, padding), new SKSamplingOptions());
        
        using var font = new SKFont { Size = 40, Typeface = SKTypeface.Default };
        using var paint = new SKPaint { Color = SKColors.Black, IsAntialias = true };
        
        float canvasCenterX = canvasWidth / 2f;

        string wifiText = $"Name: {credentials.Name}";
        string passwordText = $"Password: {credentials.Password}";

        float wifiTextWidth = font.MeasureText(wifiText, paint);
        float passwordTextWidth = font.MeasureText(passwordText, paint);

        float textY = qrBitmap.Height + padding + 50;

        canvas.DrawText(wifiText, new SKPoint(canvasCenterX - wifiTextWidth / 2f, textY), SKTextAlign.Left, font, paint);
        canvas.DrawText(passwordText, new SKPoint(canvasCenterX - passwordTextWidth / 2f, textY + 50), SKTextAlign.Left, font, paint);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);

        var currentDirectory = Directory.GetCurrentDirectory();
        var outputPath = Path.Combine(currentDirectory, $"{credentials.Name}-qrcode.png");
        File.WriteAllBytes(outputPath, data.ToArray());
        Console.WriteLine($"Outputted to: {outputPath}");
    }
}