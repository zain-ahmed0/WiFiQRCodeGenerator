class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.6"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.6/wqr-osx-arm64.tar.gz"
      sha256 "b3cac4fcf5c2b6571501d92e4b634a637977af4832701b154dab95422ec2d930"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.6/wqr-osx-x64.tar.gz"
      sha256 "5c518f72a853b61bc5ded2ae6c778d8df9557847f69765fbd4b622860d24d699"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.6/wqr-linux-x64.tar.gz"
    sha256 "0ccdabd598dbbe079efc434aa4f75bca0820626b0a6b4c88d8c87c78a470d2a9"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end