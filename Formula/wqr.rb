class Wqr < Formula
  desc "Generate a QR code for your WiFi network"
  homepage "https://github.com/zain-ahmed0/WiFiQRCodeGenerator"
  version "1.0.3"

  on_macos do
    if Hardware::CPU.arm?
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-osx-arm64.tar.gz"
      sha256 "71028ba814fede945b7e2b2efd8231a2d6aff4309e09c97e91b4c661eb0341da"
    else
      url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-osx-x64.tar.gz"
      sha256 "cf00928fbeadce716d8187c20bfbeb04a543e3419a6b3b7fbaf46b86bd4c1244"
    end
  end

  on_linux do
    url "https://github.com/zain-ahmed0/WiFiQRCodeGenerator/releases/download/v1.0.3/wqr-linux-x64.tar.gz"
    sha256 "06fe9affe48cce7cf9164ca058720220aef6c4594890ff4fa3cb773c7d7f89fd"
  end  

  def install
    bin.install "wqr"
  end

  test do
    system "#{bin}/wqr", "--help"
  end
end