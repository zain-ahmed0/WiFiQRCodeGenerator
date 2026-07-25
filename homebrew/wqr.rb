class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.1"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.1/wqr-osx-arm64.tar.gz"
      sha256 "6cd7e9912b023905e8a5204e72e75091a071589ff8a856dd483709c43569271b"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.1/wqr-osx-x64.tar.gz"
      sha256 "6cd7e9912b023905e8a5204e72e75091a071589ff8a856dd483709c43569271b"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.1/wqr-linux-x64.tar.gz"
    sha256 "6cd7e9912b023905e8a5204e72e75091a071589ff8a856dd483709c43569271b"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end