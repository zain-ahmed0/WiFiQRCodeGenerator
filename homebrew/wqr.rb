class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.2"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.2/wqr-osx-arm64.tar.gz"
      sha256 "42d74ce7dc1462dd0535fd6dd5422e547727569ff350da8e5507345a1cb2a8ea"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.2/wqr-osx-x64.tar.gz"
      sha256 "42d74ce7dc1462dd0535fd6dd5422e547727569ff350da8e5507345a1cb2a8ea"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.2/wqr-linux-x64.tar.gz"
    sha256 "42d74ce7dc1462dd0535fd6dd5422e547727569ff350da8e5507345a1cb2a8ea"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end