class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.0"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-arm64.tar.gz"
      sha256 "431e03f25ad79113005978556e929fd5c565b3681b756a9eb86e779c3377043f"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-x64.tar.gz"
      sha256 "431e03f25ad79113005978556e929fd5c565b3681b756a9eb86e779c3377043f"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-linux-x64.tar.gz"
    sha256 "431e03f25ad79113005978556e929fd5c565b3681b756a9eb86e779c3377043f"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end