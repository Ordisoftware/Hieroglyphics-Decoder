#define MyAppVersion "0.1"
#define MyAppName "Hieroglyphics Decoder"
#define MyAppNameNoSpace "HieroglyphicsDecoder"
#define MyAppExeName "Ordisoftware.Hieroglyphics.Decoder.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hieroglyphics-decoder"

[Setup]
MinVersion=0,6.1sp1
LicenseFile=..\Project\Licenses\MPL 2.0.rtf
AppCopyright=Copyright 2012-2025 Olivier Rogier
AppId={{6274AC04-C535-4174-A934-15F84A148181}
;AppMutex=a9dd30d9-bcf7-417c-9889-0cc0025d77f2
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"

[Run]
#include "Scripts\Run.iss"

[Registry]

[Tasks]
#include "Scripts\Tasks.iss"

[Icons]
#include "Scripts\Icons.iss"

[CustomMessages]
#include "Scripts\Messages.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"
