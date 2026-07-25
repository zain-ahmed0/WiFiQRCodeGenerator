class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.2"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.2/wqr-osx-arm64.tar.gz"
      sha256 "ee053c373a4565846f71a9d12ee9bd804615beaf572df10d56f8f0f0c2580901"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.2/wqr-osx-x64.tar.gz"
      sha256 "ee053c373a4565846f71a9d12ee9bd804615beaf572df10d56f8f0f0c2580901"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.2/wqr-linux-x64.tar.gz"
    sha256 "ee053c373a4565846f71a9d12ee9bd804615beaf572df10d56f8f0f0c2580901"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end