class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.0"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-arm64.tar.gz"
      sha256 "9fa59c11094edf3b858d2a8a8f1388e4e3c893f966b3cd9cdd355e4b13e20a76"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-x64.tar.gz"
      sha256 "9fa59c11094edf3b858d2a8a8f1388e4e3c893f966b3cd9cdd355e4b13e20a76"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-linux-x64.tar.gz"
    sha256 "9fa59c11094edf3b858d2a8a8f1388e4e3c893f966b3cd9cdd355e4b13e20a76"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end