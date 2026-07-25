# wqr — WiFi QR Code Generator

A CLI/TUI tool that generates an image that contains your WiFi network credentials and a QR Code to scan to join your WiFi network.

## Background

The reason behind this project was because I upgraded my internet and received a card of my new WiFi credentials but also a QR Code to scan to easily join the WiFi network.
I thought it would be cool to make a tool that would let you create your own card for your WiFi credentials to scan and I could then generate WiFi credentials for friends and family.
There are already existing websites/tools out there but I wanted to practice my C# skills and have a go at building a CLI/TUI app.

## Getting Started

### .NET tool
```bash
dotnet tool install --global WifiQRCodeGenerator
```

### Homebrew
```bash
brew tap zain-ahmed0/wqr https://github.com/zain-ahmed0/WiFiQRCodeGenerator
brew install wqr
```

## Usage

### CLI
```bash
wqr -n "NetworkName" -p "password"
```

### TUI
```bash
wqr
```
