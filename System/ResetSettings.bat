@echo off
taskkill /im Ordisoftware.Hieroglyphics.Decoder.exe
ping localhost -n 3 >NUL
start "" ..\Bin\Ordisoftware.Hieroglyphics.Decoder.exe --reset