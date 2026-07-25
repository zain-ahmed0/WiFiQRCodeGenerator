class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.0"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-arm64.tar.gz"
      sha256 "226156c088879eff2152dc7630b26f4c2ecf3378519ee36b8d8eeac50608231c"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-osx-x64.tar.gz"
      sha256 "226156c088879eff2152dc7630b26f4c2ecf3378519ee36b8d8eeac50608231c"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.0/wqr-linux-x64.tar.gz"
    sha256 "226156c088879eff2152dc7630b26f4c2ecf3378519ee36b8d8eeac50608231c"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end