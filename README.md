[![License: PML 2.0](https://img.shields.io/github/license/ordisoftware/Hieroglyphics-Decoder)](LICENSE)&nbsp;
[![GitHub repo size](https://img.shields.io/github/repo-size/ordisoftware/Hieroglyphics-Decoder)](#)&nbsp;
[![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/ordisoftware/Hieroglyphics-Decoder)](https://github.com/Ordisoftware/Hieroglyphics-Decoder/tree/main/Project)&nbsp;
[![Lines of code](https://img.shields.io/tokei/lines/github/ordisoftware/Hieroglyphics-Decoder)](https://github.com/Ordisoftware/Hieroglyphics-Decoder/tree/main/Project)&nbsp;<br/>
[![OS: Windows](https://img.shields.io/badge/Windows%207%2B-279CE8?label=os)](https://www.microsoft.com/windows/)&nbsp;
[![UI: WinForms](https://img.shields.io/badge/WinForms-279CE8?label=ui)](https://github.com/dotnet/winforms)&nbsp;
[![Framework: .Net](https://img.shields.io/badge/.NET%204.8-6E5FA6?label=framework)](https://dotnet.microsoft.com)&nbsp;
[![IDE: Visual Studio](https://img.shields.io/badge/Visual%20Studio%202022-6E5FA6.svg?label=ide)](https://visualstudio.microsoft.com)&nbsp;
[![Lang: C#](https://img.shields.io/badge/C%23%2012-%23239120.svg?label=lang)](https://docs.microsoft.com/dotnet/csharp/)&nbsp;
[![DB: SQLite](https://img.shields.io/badge/SQLite%203.44-darkgoldenrod.svg?label=db)](https://www.sqlite.org)&nbsp;<br/>
[![Ordisoftware.com Project](https://img.shields.io/badge/-Ordisoftware.com%20Project-355F90?logo=WordPress&logoColor=white)](https://www.ordisoftware.com/hieroglyphics-decoder)&nbsp;
[![Manufacturing Software Guidelines](https://img.shields.io/badge/-Manufacturing%20Software%20Guidelines-355F90?logo=MicrosoftWord&logoColor=white)](https://github.com/Ordisoftware/Guidelines)&nbsp;

# Hieroglyphics Decoder

A libre and open-source software written in C# that helps for the rebus hieroglyph-by-hieroglyph study and analysis of shenus or cartouches and frescoes of ancient Egypt.

## Table of content

1. [Functionalities](#functionalities)
2. [Requirements](#requirements)
3. [Frequently asked questions](#frequently-asked-questions)
4. [Keyboard shortcuts](#keyboard-shortcuts)
5. [Changelog](#changelog)

## Functionalities

- Hieroglyphs database with their customizable meanings.
- Analyze a shenu hieroglyph-by-hieroglyph to get a sentence describing its sense.
- Online research using several dictionaries.
- Store results in a notebook.
- Copy the result or a screenshot to the clipboard.
- English, French.

## Requirements

- Screen 1024x768 or higher
- Windows 7 SP1 x32/x64 or higher
- Framework .NET 4.8
- SQLite 3.44

## Frequently asked questions

#### What code analyzers are used in addition to Visual Studio?

|IDE Extension|Project NuGet| 
|-|-|
|[SonarLint](https://marketplace.visualstudio.com/items?itemName=SonarSource.SonarLintforVisualStudio2022)<br>[Roslynator](https://marketplace.visualstudio.com/items?itemName=josefpihrt.Roslynator2022)<br>[F0.Analyzers](https://marketplace.visualstudio.com/items?itemName=Flash0Ware.F0-Analyzers-VS)<br>[Parallel Helper](https://marketplace.visualstudio.com/items?itemName=camrein.ParallelHelper)<br>[Parallel Checker](https://marketplace.visualstudio.com/items?itemName=LBHSR.ParallelChecker)<br>[AsyncFixer](https://marketplace.visualstudio.com/items?itemName=SemihOkur.AsyncFixer2022)<br>[Async Method Name Fixer](https://marketplace.visualstudio.com/items?itemName=PRIYANSHUAGRAWAL92.AsyncMethodNameFixer)<br>[U2U Consult Performance Analyzers](https://marketplace.visualstudio.com/items?itemName=vs-publisher-363830.U2UConsultPerformanceCodeAnalyzersforC7)<br>[TSQL Analyzer](https://github.com/Zefek/TSQLAnalyzer)<br>[Serilog Analyzer](https://github.com/Suchiman/SerilogAnalyzer)<br>[Security Code Scan](https://marketplace.visualstudio.com/items?itemName=JaroslavLobacevski.SecurityCodeScanVS2019)<br>[Puma Scan](https://marketplace.visualstudio.com/items?itemName=PumaSecurity.PumaScan)<br>[SharpSource](https://github.com/Vannevelj/SharpSource)<br>[Inclusiveness Analyzer](https://github.com/microsoft/InclusivenessAnalyzerVisualStudio)|[Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)<br>[Microsoft.VisualStudio.Threading.Analyzers](https://github.com/microsoft/vs-threading)<br>[MultithreadingAnalyzer](https://github.com/cezarypiatek/MultithreadingAnalyzer)<br>[Meziantou.Analyzer](https://github.com/meziantou/Meziantou.Analyzer)<br>[GCop.All.Common](https://github.com/Geeksltd/GCop)<br>[ReflectionAnalyzers](https://github.com/DotNetAnalyzers/ReflectionAnalyzers)<br>[IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)<br>[ErrorProne.NET.CoreAnalyzers](https://github.com/SergeyTeplyakov/ErrorProne.NET)<br>[ErrorProne.NET.Structs](https://github.com/SergeyTeplyakov/ErrorProne.NET)<br><br><br><br><br><br>|

#### What to do if the check update tells that the SSL certificate is wrong or expired?

The software verifies the validity of the certificate of the update server in addition to the SHA-512 checksum of the installation file before downloading and running it.

You can manually check the latest version available online in case of problem.

#### What to do if the application does not work normally despite restoring settings?

Use the Start Menu link:

&emsp;`Ordisoftware\Hieroglyphics Decoder\Reset Hieroglyphics Decoder settings`

This will erase all settings as well as those of old versions, which should resolve issues if there is a conflict, otherwise please contact support.

#### What is the Windows double-buffering?

When enabled, this will speed up rendering of the main form when it is displayed, but it may cause a slight black flicker.

When disabled, top menu and some controls painting may cause latency, and dynamic items can be generated slowly the larger the number.

## Keyboard shortcuts

| Keys | Actions |
|-|-|
| Ctrl + Tab | Next view |
| Shift + Ctrl + Tab | Previous view |
| F1 | Analysis view |
| F2 | Data view |
| F3 | Notebook view |
| F5 (or Ctrl + F) | Search
| Alt + N | New window |
| Alt + T | Tools menu |
| Alt + L | Web links menu |
| Alt + S | Settings menu |
| Alt + I | Information menu |
| F9 | Preferences |
| F10 | Log file window |
| F11 | Usage statistics window |
| F12 | About |
| Alt + F4 (or Escape) | Exit application |

## Changelog

#### 2021.10.02

- GitHub repo created.