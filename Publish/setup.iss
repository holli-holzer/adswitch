; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "ADSwitch"
#define MyAppVersion "0.0815"
#define MyAppPublisher "Bill Stinks Inc."
#define MyAppURL "http://www.example.com/"
#define MyAppExeName "ADSwitchW.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
PrivilegesRequired=admin
AppId={{8AD51051-4A3F-48A1-A5C2-1D15F1214D23}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputBaseFilename="{#MyAppName}Installer"
Compression=lzma
SolidCompression=yes


[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "autoicon"; Description: "Add to &Autostart"


[Files]
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitchW.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitchW.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitchW.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitchW.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchC\ADSwitchC\bin\Release\ADSwitchC.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchC\ADSwitchC\bin\Release\ADSwitchC.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchC\ADSwitchC\bin\Release\ADSwitchC.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitch.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitch.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\ADSwitchW\ADSwitchW\bin\Release\ADSwitch.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\License.txt"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{commonstartup}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: autoicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

