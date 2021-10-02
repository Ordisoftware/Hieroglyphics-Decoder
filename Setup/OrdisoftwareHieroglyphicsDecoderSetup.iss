#define MyAppVersion "0.0"
#define MyAppName "Hieroglyphics Decoder"
#define MyAppNameNoSpace "HieroglyphicsDecoder"
#define MyAppExeName "Ordisoftware.Hieroglyphics.Decoder.exe"
#define MyAppPublisher "Ordisoftware"
#define MyAppURL "https://www.ordisoftware.com/projects/hieroglyphics-decoder"

[Setup]
AppCopyright=Copyright 2012-2021 Olivier Rogier
AppId={{}
;AppMutex=
#include "Scripts\Setup.iss"

[Languages]
#include "Scripts\Languages.iss"

[CustomMessages]
#include "Scripts\Messages.iss"

[Tasks]
#include "Scripts\Tasks.iss"


[Dirs]

[InstallDelete]
#include "Scripts\InstallDelete.iss"

[Files]
#include "Scripts\Files.iss"

[Icons]
#include "Scripts\Icons.iss"


[Registry]


[Run]
#include "Scripts\Run.iss"

[Code]
#include "Scripts\CheckDotNetFramework.iss"
