// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Memory.iOS
{
    [Register ("EventsViewController")]
    partial class EventsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EvilButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EvilButton != null) {
                EvilButton.Dispose ();
                EvilButton = null;
            }
        }
    }
}