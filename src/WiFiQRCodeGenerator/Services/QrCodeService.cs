using QRCoder;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Services;

public static class QrCodeService
{
    public static byte[] Generate(WiFiCredentials credentials)
    {
        var wifiPayload = new PayloadGenerator.WiFi(credentials.Name, credentials.Password, PayloadGenerator.WiFi.Authentication.WPA2);
        var qrCodeData = QRCodeGenerator.GenerateQrCode(wifiPayload, QRCodeGenerator.ECCLevel.Q);
            
        using var pngRenderer = new PngByteQRCode(qrCodeData);
            
        return pngRenderer.GetGraphic(20);
    }
}