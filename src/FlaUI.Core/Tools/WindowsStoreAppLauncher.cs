﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SeraphSecure.FlaUI.Core.Tools
{
    /// <summary>
    /// Class with methods to launch windows store apps.
    /// </summary>
    public static class WindowsStoreAppLauncher
    {
        /// <summary>
        /// Launch the store app with the given id and arguments.
        /// </summary>
        /// <param name="appUserModelId">The app id of the application to launch.</param>
        /// <param name="arguments">The arguments to pass to the application.</param>
        /// <returns>The process of the launched application.</returns>
        public static Process Launch(string appUserModelId, string arguments)
        {
            var launcher = new ApplicationActivationManager();
            var hr = launcher.ActivateApplication(appUserModelId, arguments, ActivateOptions.None, out var processId).ToInt32();
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
            if (processId > 0)
            {
                return Process.GetProcessById((int)processId);
            }
            throw new Exception($"Could not launch Store App '{appUserModelId}'");
        }

        #region Win32
        // ReSharper disable InconsistentNaming
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [Flags]
        public enum ActivateOptions
        {
            None = 0x00000000,
            DesignMode = 0x00000001,
            NoErrorUI = 0x00000002,
            NoSplashScreen = 0x00000004
        }

        [ComImport, Guid("2E941141-7F97-4756-BA1D-9DECDE894A3D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IApplicationActivationManager
        {
            IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);
            IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [In] string verb, [Out] out uint processId);
            IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [Out] out uint processId);
        }

        [ComImport, Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]
        private class ApplicationActivationManager : IApplicationActivationManager
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [In] string verb, [Out] out uint processId);

            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            public extern IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /*IShellItemArray*/ itemArray, [Out] out uint processId);
        }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        // ReSharper restore InconsistentNaming
        #endregion Win32
    }
}
