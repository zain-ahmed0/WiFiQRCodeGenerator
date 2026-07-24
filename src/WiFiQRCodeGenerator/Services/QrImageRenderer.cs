using SkiaSharp;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Services;

public static class QrImageRenderer
{
    public static void Render(byte[] qrBytes, WiFiCredentials credentials)
    {
        var qrBitmap = SKBitmap.Decode(qrBytes);
        
        int padding = 50;
        int textHeight = 120;
        int canvasWidth = qrBitmap.Width + padding * 2;
        int canvasHeight = qrBitmap.Height + padding * 2 + textHeight;
            
        using var surface = SKSurface.Create(new SKImageInfo(canvasWidth, canvasHeight));
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.White);
            
        canvas.DrawBitmap(qrBitmap, new SKPoint(padding, padding));

        using var font = new SKFont
        {
            Size = 40,
            Typeface = SKTypeface.Default
        };
            
        using var paint = new SKPaint
        {
            Color = SKColors.Black,
            IsAntialias = true,
        };
            
        float canvasCenterX = canvasWidth / 2f;

        string wifiText = $"Name: {credentials.Name}";
        string passwordText = $"Password: {credentials.Password}";
            
        float wifiTextWidth = font.MeasureText(wifiText, paint);
        float passwordTextWidth = font.MeasureText(passwordText, paint);
            
        float textY = qrBitmap.Height + padding + 50;
            
        canvas.DrawText(wifiText, new SKPoint(canvasCenterX - wifiTextWidth / 2f, textY), font, paint);

        canvas.DrawText(passwordText, new SKPoint(canvasCenterX - passwordTextWidth / 2f, textY + 50), font, paint);
            
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            
        var currentDirectory = Directory.GetCurrentDirectory();
        File.WriteAllBytes(Path.Combine(currentDirectory, $"{credentials.Name}-qrcode.png"), data.ToArray());
        Console.WriteLine($"Outputted to: {Directory.GetCurrentDirectory()}");
    }
}