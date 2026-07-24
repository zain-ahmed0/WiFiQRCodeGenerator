update:
	cd src/WiFiQRCodeGenerator && dotnet pack && dotnet tool uninstall --global WifiQRCodeGenerator ; dotnet tool install --global --add-source ./bin/Release WifiQRCodeGenerator