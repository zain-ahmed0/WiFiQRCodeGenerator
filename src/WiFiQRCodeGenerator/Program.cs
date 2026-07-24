using System.CommandLine;
using QRCoder;
using SkiaSharp;

namespace WifiQRCodeGenerator;

public static class WifiQrCodeGenerator
{
    public static int Main(string[] args)
    {
        RootCommand rootCommand = new("WifiQRCodeGenerator");

        Option<string> wifiOption = new("--wifi", "-w")
        {
            Description = "WiFi"
        };
        
        Option<string> passwordOption = new("--password", "-p")
        {
            Description = "Password"
        };
        
        rootCommand.Options.Add(wifiOption);
        rootCommand.Options.Add(passwordOption);
        
        rootCommand.SetAction(parseResult =>
        {
            string? wifi = parseResult.GetValue(wifiOption);
            string? password = parseResult.GetValue(passwordOption);
            Console.WriteLine($"WiFi: {wifi}\nPassword: {password}" );
            
            var wifiPayload = new PayloadGenerator.WiFi(wifi, password, PayloadGenerator.WiFi.Authentication.WPA2);
            // using var qrCodeData = QRCodeGenerator.GenerateQrCode(wifiPayload, QRCodeGenerator.ECCLevel.Q);
            var qrCodeData = QRCodeGenerator.GenerateQrCode(wifiPayload, QRCodeGenerator.ECCLevel.Q);
            // using var svgRenderer = new SvgQRCode(qrCodeData);

            // string svg = svgRenderer.GetGraphic();
            using var pngRenderer = new PngByteQRCode(qrCodeData);
            
            byte[] qrCodeImage = pngRenderer.GetGraphic(20);
            
            // Image<Rgba32> qrImage = Image.Load<Rgba32>(qrCodeImage);
            using var qrBitmap = SKBitmap.Decode(qrCodeImage);

            // Image canvas = new Image<Rgba32>(1200, 1000);

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
                // TextSize = 40,
                IsAntialias = true,
                // Typeface = SKTypeface.Default
            };
            
            float canvasCenterX = canvasWidth / 2f;

            string wifiText = $"WiFi Name: {wifi}";
            string passwordText = $"Password: {password}";
            
            float wifiTextWidth = font.MeasureText(wifiText, paint);
            float passwordTextWidth = font.MeasureText(passwordText, paint);
            
            float textY = qrBitmap.Height + padding + 50;
            
            canvas.DrawText(wifiText, new SKPoint(canvasCenterX - wifiTextWidth / 2f, textY), font, paint);

            canvas.DrawText(passwordText, new SKPoint(canvasCenterX - passwordTextWidth / 2f, textY + 50), font, paint);

            Directory.CreateDirectory("output");
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            File.WriteAllBytes($"output/{wifi}-qrcode.png", data.ToArray());
            Console.WriteLine($"Outputted to: {Directory.GetCurrentDirectory()}");

            // canvas.DrawText(password, padding, textY + 50, paint);


            // var fonts = new FontCollection();
            // var mainFont = fonts.Add("fonts/Arial.ttf");
            //
            // string text = $"WiFi Name: {wifi}\nPassword: {password}";
            //
            // RichTextOptions textOptions = new(mainFont.CreateFont(39, FontStyle.Regular))
            // {
            //     HorizontalAlignment = HorizontalAlignment.Center,
            //     VerticalAlignment = VerticalAlignment.Center,
            //     Origin = new PointF(400, 95),
            // };
            //
            // canvas.Mutate(ctx =>
            //     ctx.DrawImage(qrImage, new Point(x: 50, y: 50), opacity: 1)
            //         .DrawText(textOptions, text, new SolidBrush(Color.Aqua)));
            //
            // canvas.Save("output/test.png");

            // Text Work
            // using Image img = new Image<Rgba32>(1500, 500);
            // const string text = "Test";

            // Decode png image
            // SixLabors compatible
            // Generate text
            // Generate background
            // Combine and put into one canvas

            // var outputPath = Path.Combine(
            //     Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName,
            //     "output"
            // );

            // var filePath = Path.Combine(outputPath, "qrCode.png");

            // File.WriteAllBytes(filePath, qrCodeImage);
        });
        
        return rootCommand.Parse(args).Invoke();
    }
}