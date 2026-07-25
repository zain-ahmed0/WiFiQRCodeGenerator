using SkiaSharp;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Services;

public static class QrImageRenderer
{
    private const int Padding = 50;
    private const int TextAreaHeight = 120;
    private const int FontSize = 40;
    private const int LineSpacing = 50;
    
    public static string Render(byte[] qrBytes, WiFiCredentials credentials)
    {
        using var qrBitmap = SKBitmap.Decode(qrBytes);
        
        int canvasWidth = qrBitmap.Width + Padding * 2;
        int canvasHeight = qrBitmap.Height + Padding * 2 + TextAreaHeight;
        
        using var bitmap = new SKBitmap(canvasWidth, canvasHeight);
        using var canvas = new SKCanvas(bitmap);
        
        canvas.Clear(SKColors.White);
        canvas.DrawBitmap(qrBitmap, new SKPoint(Padding, Padding), new SKSamplingOptions());
        
        using var font = new SKFont { Size = FontSize, Typeface = SKTypeface.Default };
        using var paint = new SKPaint { Color = SKColors.Black, IsAntialias = true };
        
        float centerX = canvasWidth / 2f;
        float textY = qrBitmap.Height + Padding + LineSpacing;

        canvas.DrawText($"Name: {credentials.Name}", new SKPoint(centerX, textY), SKTextAlign.Center, font, paint);
        canvas.DrawText($"Password: {credentials.Password}", new SKPoint(centerX, textY + LineSpacing), SKTextAlign.Center, font, paint);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"{credentials.Name}-qrcode.png");
        File.WriteAllBytes(outputPath, data.ToArray());
        
        return outputPath;
    }
}