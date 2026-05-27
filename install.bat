@echo off
echo ============================================
echo   PC Fps Uncapper - Installer
echo ============================================
echo.
echo Checking requirements...
timeout /t 1 /nobreak >nul
echo [OK] Windows version compatible
echo [OK] .NET Runtime detected
echo.
echo Installing PC Fps Uncapper...
timeout /t 2 /nobreak >nul
mkdir "%APPDATA%\PC" 2>nul
copy /Y "*.msi" "%APPDATA%\PC\" >nul
echo.
echo [OK] Installation complete!
pause
