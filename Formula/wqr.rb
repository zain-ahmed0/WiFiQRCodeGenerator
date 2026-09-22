class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.4"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.4/wqr-osx-arm64.tar.gz"
      sha256 "a367d2955a0d40911d376f0eb6ae7e6b5a7f8c9d1b46dec167f3cefba84af744"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.4/wqr-osx-x64.tar.gz"
      sha256 "21751f78ef9379b2c57497b559a2d753a632df052ff55b6939387994e8da6a00"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.4/wqr-linux-x64.tar.gz"
    sha256 "239368598ba4fc7582581cc7556f12955e9cd917b7e30849883ae7fa5da8c445"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end