﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxLogListener.cs" company="WildGums">
//   Copyright (c) 2008 - 2014 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Analytics.Example.Logging
{
    using System;
    using System.Windows.Controls;
    using Catel;
    using Catel.Logging;

    public class TextBoxLogListener : LogListenerBase
    {
        private readonly TextBox _textBox;

        public TextBoxLogListener(TextBox textBox)
        {
            Argument.IsNotNull(() => textBox);

            _textBox = textBox;

            IgnoreCatelLogging = true;
        }

        public void Clear()
        {
            _textBox.Dispatcher.Invoke(new Action(() => _textBox.Clear()));
        }

        protected override void Write(ILog log, string message, LogEvent logEvent, object extraData, DateTime time)
        {
            _textBox.Dispatcher.Invoke(new Action(() =>
            {
                _textBox.AppendText(string.Format("{0} [{1}] {2}", time.ToString("hh:mm:ss.fff"), logEvent.ToString().ToUpper(), message));
                _textBox.AppendText(Environment.NewLine);
                _textBox.ScrollToEnd();
            }));
        }
    }
}