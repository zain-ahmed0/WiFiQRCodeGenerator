class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.5"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.5/wqr-osx-arm64.tar.gz"
      sha256 "67035ea035e225adc8a347086c663be8541482447fb4f82bce15336cfc42a508"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.5/wqr-osx-x64.tar.gz"
      sha256 "11b28640c0bac1c52efb9782560b0fe8b28c3fe9fa9c7fba40dd24aacf754bbb"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.5/wqr-linux-x64.tar.gz"
    sha256 "0e1547da19e40dc99bbb8a4890b2e68393ba93ae952237d18caf68f0f0bd56e1"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end