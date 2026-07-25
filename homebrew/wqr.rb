class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.0"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-arm64.tar.gz"
      sha256 "5638ed0326a8f86ec060a1b7dcc57bd6aba925e7c548cfe6faee688061af3f9d"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-x64.tar.gz"
      sha256 "5638ed0326a8f86ec060a1b7dcc57bd6aba925e7c548cfe6faee688061af3f9d"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-linux-x64.tar.gz"
    sha256 "5638ed0326a8f86ec060a1b7dcc57bd6aba925e7c548cfe6faee688061af3f9d"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end