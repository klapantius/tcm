using System;
using System.Runtime.InteropServices;

namespace TestControllerManager.View.WinAPI
{
    internal static class NativeMethods
    {
        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window.
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// <see href="https://msdn.microsoft.com/de-de/library/windows/desktop/ms633519.aspx" />
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        /// <summary>
        /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
        /// <see href="https://msdn.microsoft.com/de-de/library/windows/desktop/dd162897.aspx" />
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        // ReSharper disable once InconsistentNaming
        public struct RECT
        {
            /// <summary>
            /// The x-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Left; // x position of upper-left corner

            /// <summary>
            /// The y-coordinate of the upper-left corner of the rectangle.
            /// </summary>
            public int Top; // y position of upper-left corner

            /// <summary>
            /// The x-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Right; // x position of lower-right corner

            /// <summary>
            /// The y-coordinate of the lower-right corner of the rectangle.
            /// </summary>
            public int Bottom; // y position of lower-right corner
        }
    }
}
