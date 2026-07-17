@echo off
taskkill /im Ordisoftware.Hieroglyphics.Decoder.exe
rem ping localhost -n 3 >NUL //OBSOLETE WIN0+
timeout /t 2 /nobreak >NUL
start "" ..\Bin\Ordisoftware.Hieroglyphics.Decoder.exe --reset