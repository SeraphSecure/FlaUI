﻿using System;

namespace SeraphSecure.FlaUI.Core.WindowsAPI
{
    public static class Delegates
    {
        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);
    }
}
