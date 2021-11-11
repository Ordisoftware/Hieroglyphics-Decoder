﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-03 </created>
/// <edited> 2021-10 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide online provider item.
  /// </summary>
  partial class OnlineProviderItem
  {

    static public readonly Image FolderImage = CreateImage("folder_vertical_open.png");

    static public readonly Dictionary<string, Image> LanguageImages
      = new Dictionary<string, Image>()
      {
        ["(NONE)"] = CreateImage("web_layout.png"),
        ["(FR)"] = CreateImage("flag_france.png"),
        ["(EN)"] = CreateImage("flag_great_britain.png"),
        ["(IW)"] = CreateImage("flag_israel.png"),
        ["(EN/IW)"] = CreateImage("flag_en_iw.png"),
        ["(FR/IW)"] = CreateImage("flag_fr_iw.png"),
        ["(FR/EN)"] = CreateImage("flag_fr_en.png")
      };

    static private Image CreateImage(string filePath)
    {
      try
      {
        return Image.FromFile(System.IO.Path.Combine(Globals.HelpFolderPath, filePath));
      }
      catch ( Exception ex )
      {
        DebugManager.Trace(LogTraceEvent.Exception, new ExceptionInfo(null, ex).FullText);
        return null;
      }
    }

    public string Language { get; private set; }

    public string Name { get; private set; }

    public string URL { get; private set; }

    public Image Image { get; private set; }

    public ToolStripItem CreateMenuItem(EventHandler action)
    {
      if ( Name == "-" ) return new ToolStripSeparator();
      var result = new ToolStripMenuItem(Name, Image);
      result.ImageScaling = ToolStripItemImageScaling.None;
      result.Tag = URL;
      result.Click += action;
      return result;
    }

    public OnlineProviderItem(string name, string url = "", Image image = null)
    {
      string lang = string.Empty;
      if ( name[0] == '(' )
      {
        int pos = name.IndexOf(')');
        if ( pos >= 3 )
        {
          lang = name.Substring(0, pos + 1);
          if ( LanguageImages.ContainsKey(lang) )
          {
            name = name.Substring(pos + 1);
            image = LanguageImages[lang];
          }
        }
      }
      Language = lang;
      Name = name.Trim();
      URL = url.Trim();
      Image = image;
    }

  }

}