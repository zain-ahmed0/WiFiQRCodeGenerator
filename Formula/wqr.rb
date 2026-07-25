class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.3"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-osx-arm64.tar.gz"
      sha256 "a5b14f5fcbf0358673bc096948da5ad960b6f8cdf3f9ad1c23119e0484daa76e"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-osx-x64.tar.gz"
      sha256 "a5b14f5fcbf0358673bc096948da5ad960b6f8cdf3f9ad1c23119e0484daa76e"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-linux-x64.tar.gz"
    sha256 "a5b14f5fcbf0358673bc096948da5ad960b6f8cdf3f9ad1c23119e0484daa76e"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end