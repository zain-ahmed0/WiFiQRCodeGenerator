using QRCoder;
using Spectre.Console;
using WifiQRCodeGenerator.Models;

namespace WifiQRCodeGenerator.Services;

public static class QrCodeService
{
    private const int GraphicPixelNumber = 20;
    public static byte[] Generate(WiFiCredentials credentials)
    {
        var authType = credentials.Auth switch
        {
            AuthType.WPA2 => PayloadGenerator.WiFi.Authentication.WPA2,
            AuthType.WPA => PayloadGenerator.WiFi.Authentication.WPA,
            AuthType.WEP => PayloadGenerator.WiFi.Authentication.WEP,
            AuthType.NOPASS => PayloadGenerator.WiFi.Authentication.nopass,
            _ => throw new ArgumentOutOfRangeException(nameof(credentials.Auth), credentials.Auth, null)
        };
        
        var wifiPayload = new PayloadGenerator.WiFi(credentials.Name, credentials.Password, authType);
        var qrCodeData = QRCodeGenerator.GenerateQrCode(wifiPayload, QRCodeGenerator.ECCLevel.Q);

        using var pngRenderer = new PngByteQRCode(qrCodeData);

        return pngRenderer.GetGraphic(GraphicPixelNumber);
    }
}