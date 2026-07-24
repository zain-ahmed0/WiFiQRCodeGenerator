using QRCoder;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Services;

public static class QrCodeService
{
    public static byte[] Generate(WiFiCredentials credentials)
    {
        var authType = credentials.Auth.ToUpper() switch
        {
            "WPA2" => PayloadGenerator.WiFi.Authentication.WPA2,
            "WPA" => PayloadGenerator.WiFi.Authentication.WPA,
            "WEP" => PayloadGenerator.WiFi.Authentication.WEP,
            "NOPASS" => PayloadGenerator.WiFi.Authentication.nopass,
            _ => PayloadGenerator.WiFi.Authentication.WPA2
        };
        
        var wifiPayload = new PayloadGenerator.WiFi(credentials.Name, credentials.Password, authType);
        var qrCodeData = QRCodeGenerator.GenerateQrCode(wifiPayload, QRCodeGenerator.ECCLevel.Q);

        using var pngRenderer = new PngByteQRCode(qrCodeData);

        return pngRenderer.GetGraphic(20);
    }
}