﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides system management.
/// </summary>
static public partial class SystemManager
{

  /// <summary>
  /// Indicates command line arguments.
  /// </summary>
  static public List<string> CommandLineArguments { get; private set; }

  /// <summary>
  /// Indicates command line arguments options instance.
  /// </summary>
  static public SystemCommandLine CommandLineOptions { get; private set; }

  /// <summary>
  /// Analyses the command line arguments.
  /// </summary>
  static public void CheckCommandLineArguments<T>(string[] args, ref Language language)
  where T : SystemCommandLine, new()
  {
    try
    {
      CommandLineArguments = [.. args];
      var options = CommandLine.Parser.Default.ParseArguments<T>(args);
      if ( options.Tag != CommandLine.ParserResultType.Parsed )
      {
        CommandLineOptions = new T();
        return;
      }
      CommandLineOptions = ( (CommandLine.Parsed<T>)options ).Value;
      if ( !CommandLineOptions.Language.IsNullOrEmpty() )
        foreach ( var lang in Languages.Values.Where(lang => CommandLineOptions.Language.RawEquals(lang.Key)) )
          language = lang.Value;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

  /// <summary>
  /// Checks if a file is an executable.
  /// </summary>
  [SuppressMessage("Design", "MA0060:The value returned by Stream.Read/Stream.ReadAsync is not used", Justification = "N/A")]
  [SuppressMessage("Minor Bug", "S2674:The length returned from a stream read should be checked", Justification = "N/A")]
  static public bool CheckIfFileIsExecutable(string filePath)
  {
    try
    {
      var firstTwoBytes = new byte[2];
      using ( var fileStream = File.Open(filePath, FileMode.Open) )
        fileStream.Read(firstTwoBytes, 0, 2);
      return Encoding.UTF8.GetString(firstTwoBytes) == "MZ";
    }
    catch ( Exception ex )
    {
      throw new IOException(SysTranslations.FileAccessError.GetLang(filePath, ex.Message));
    }
  }

  /// <summary>
  /// Starts a process and return its managed instance.
  /// </summary>
  /// <param name="filePath">The file path.</param>
  /// <param name="arguments">The command line arguments.</param>
  /// <param name="asAdmin">True if run as admin.</param>
  /// <param name="style">Process Window Style.</param>
  static public Process GetRunShell(string filePath, string arguments = "", bool asAdmin = false, ProcessWindowStyle style = ProcessWindowStyle.Normal)
  {
    var process = new Process();
    try
    {
      process.StartInfo.FileName = filePath;
      process.StartInfo.Arguments = arguments;
      process.StartInfo.WindowStyle = style;
      if ( asAdmin )
      {
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.Verb = "runas";
      }
      process.Start();
      return process;
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(SysTranslations.RunSystemManagerError.GetLang(filePath, ex.Message));
      return null;
    }
  }

  /// <summary>
  /// Starts a process.
  /// </summary>
  /// <param name="filePath">The file path.</param>
  /// <param name="arguments">The command line arguments.</param>
  /// <param name="asAdmin">True if run as admin.</param>
  /// <param name="style">Process Window Style.</param>
  static public void RunShell(string filePath, string arguments = "", bool asAdmin = false, ProcessWindowStyle style = ProcessWindowStyle.Normal)
  {
    using var process = GetRunShell(filePath, arguments, asAdmin, style);
  }

  /// <summary>
  /// Adds "mailto:" to a string if it does not start with "mailto:".
  /// </summary>
  /// <param name="link">The link.</param>
  /// <returns>
  /// The openable mail link.
  /// </returns>
  static public string MakeMailLink(string link)
  {
    return !link.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase)
      ? $"mailto:{link}"
      : link;
  }

  /// <summary>
  /// Opens a mail link.
  /// </summary>
  /// <param name="link">The mail address.</param>
  static public void OpenMailLink(string link)
  {
    RunShell(MakeMailLink(link));
  }

  /// <summary>
  /// Adds "http://" to a string if it does not start with http:// or https://.
  /// </summary>
  /// <param name="link">The link.</param>
  /// <returns>
  /// The browsable link.
  /// </returns>
  static public string MakeWebLink(string link)
  {
    return !link.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
        && !link.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
      ? $"http://{link}"
      : link;
  }

  /// <summary>
  /// Opens a web link.
  /// </summary>
  /// <param name="link">The link.</param>
  static public void OpenWebLink(string link)
  {
    if ( link.IsNullOrEmpty() ) return;
    RunShell(MakeWebLink(link));
  }

  /// <summary>
  /// Opens the application home page.
  /// </summary>
  static public void OpenApplicationHome()
  {
    OpenWebLink(Globals.ApplicationHomeURL);
  }

  /// <summary>
  /// Opens the application home page.
  /// </summary>
  static public void OpenApplicationReleaseNotes()
  {
    OpenWebLink(string.Format(Globals.ApplicationReleaseNotesURL, Globals.AssemblyVersion));
  }

  /// <summary>
  /// Opens the author home page.
  /// </summary>
  static public void OpenAuthorHome()
  {
    OpenWebLink(Globals.AuthorHomeURL);
  }

  /// <summary>
  /// Opens the author contact page.
  /// </summary>
  static public void OpenContactPage()
  {
    OpenWebLink(Globals.AuthorContactURL);
  }

  /// <summary>
  /// Opens GitHub repository.
  /// </summary>
  static public void OpenGitHubRepo()
  {
    OpenWebLink(Globals.GitHubRepositoryURL);
  }

  /// <summary>
  /// Creates a GitHub issue.
  /// </summary>
  static public void CreateGitHubIssue(string query = "")
  {
    OpenWebLink(Globals.GitHubCreateIssueURL + query);
  }

  /// <summary>
  /// Gets the SHA-512 checksum of a file.
  /// </summary>
  static public string GetChecksumSHA512(string filePath)
  {
    try
    {
      using var stream = File.OpenRead(filePath);
      using var sha = System.Security.Cryptography.SHA512.Create();
      return BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
    }
    catch ( Exception ex )
    {
      throw new IOException(SysTranslations.FileAccessError.GetLang(filePath), ex);
    }
  }

  /// <summary>
  /// Closes the running applications being the same as the current.
  /// </summary>
  /// <param name="reason">The reason.</param>
  static public void CloseRunningApplications(string reason)
  {
    var result = DialogResult.None;
    var processes = Globals.ConcurrentRunningProcesses;
    while ( processes.Any() && result != DialogResult.Cancel )
    {
      var list = processes.Select(p => p.ProcessName);
      var names = list.AsMultiLine();
      string message = SysTranslations.CloseApplicationsRequired.GetLang(reason, names.Indent(5, 5));
      using ( var form = new MessageBoxEx(Globals.AssemblyTitle,
                                          message,
                                          MessageBoxButtons.RetryCancel,
                                          MessageBoxIcon.Exclamation) )
      {
        form.ActionYes.Visible = true;
        form.AcceptButton = form.ActionYes;
        form.CancelButton = form.ActionCancel;
        form.ActiveControl = form.ActionRetry;
        form.ShowInTaskbar = true;
        result = form.ShowDialog();
      }
      if ( result == DialogResult.Yes )
        foreach ( var process in processes )
          TryCatch(process.Kill);
      Thread.Sleep(2000);
      processes = Globals.ConcurrentRunningProcesses;
    }
    if ( processes.Any() || result == DialogResult.Cancel ) Terminate();
  }

}
