@echo on

REM Sets where InnoSetup is installed
SET INNO="c:\Program Files (x86)\Inno Setup 5"

REM Sets where 7zip is installed
SET SZIP="c:\Program Files\7-Zip"

REM Compile Setup-Script
%INNO%\iscc setup.iss

REM Zip up the Setup
cd Output
%SZIP%\7z a ADSwitchInstaller.zip ADSwitchInstaller.exe