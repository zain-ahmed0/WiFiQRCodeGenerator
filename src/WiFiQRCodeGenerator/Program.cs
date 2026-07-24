using WifiQRCodeGenerator.Commands;

namespace WifiQRCodeGenerator;

public static class WifiQrCodeGenerator
{
    public static int Main(string[] args)
    {
        return GenerateCommand.Run(args);
    }
}