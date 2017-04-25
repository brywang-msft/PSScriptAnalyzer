﻿using System;
using System.Management.Automation.Language;

namespace Microsoft.Windows.PowerShell.ScriptAnalyzer
{
    /// <summary>
    /// Class to provide information about an edit
    /// </summary>
    public class TextEdit
    {
        public IScriptExtent ScriptExtent { get; private set; }
        public int StartLineNumber { get { return ScriptExtent.StartLineNumber; } }
        public int StartColumnNumber { get { return ScriptExtent.StartColumnNumber; } }
        public int EndLineNumber { get { return ScriptExtent.EndLineNumber; } }
        public int EndColumnNumber { get { return ScriptExtent.EndColumnNumber; } }
        public string NewText { get; private set; }

        /// <summary>
        /// Creates an object of TextEdit.
        /// </summary>
        /// <param name="scriptExtent">Extent of script that needs to be replaced.</param>
        /// <param name="newText">Text that will replace the region covered by scriptExtent.</param>
        public TextEdit(IScriptExtent scriptExtent, string newText)
        {
            if (scriptExtent == null)
            {
                throw new ArgumentNullException(nameof(scriptExtent));
            }

            if (newText == null)
            {
                throw new ArgumentNullException(nameof(newText));
            }

            ScriptExtent = scriptExtent;
            NewText = newText;
        }

        public TextEdit(
            int startLineNumber,
            int startColumnNumber,
            int endLineNumber,
            int endColumnNumber,
            string newText)
            : this(new ScriptExtent(
                new ScriptPosition(null, startLineNumber, startColumnNumber, null),
                new ScriptPosition(null, endLineNumber, endColumnNumber, null)),
                newText)
        {

        }
    }
}