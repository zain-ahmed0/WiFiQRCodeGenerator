class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.4"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.4/wqr-osx-arm64.tar.gz"
      sha256 "4eba5e7d1fdf8cf31e1b3f7a81518fc0fe515d87be79558d1dd7183bb1cac923"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.4/wqr-osx-x64.tar.gz"
      sha256 "37dfe82af85e0e160abc78c87c2efb86736df2da148de594419c8923c735d07b"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.4/wqr-linux-x64.tar.gz"
    sha256 "5ec6c4ee97433f7941af9331b1045997c8b4af9f08e969fc57006cbb62a8e898"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end