class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.3"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-osx-arm64.tar.gz"
      sha256 "c1f7fa8beb792980f64a6ff8313a1689a9e93e73adbf0b91cac3b5b8cbfb26c5"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-osx-x64.tar.gz"
      sha256 "9373a4614d686a52c7987e9f9150fe32df9aa6d462598334e46d57d736cbce35"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-linux-x64.tar.gz"
    sha256 "6ee3bda18ba9e8df0f8a306824193fa09533e2e551c2e4b283f1b826a4dd4dd6"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end