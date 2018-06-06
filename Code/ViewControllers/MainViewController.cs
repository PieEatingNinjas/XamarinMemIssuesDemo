using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace Memory.iOS.ViewControllers
{
    public class MainViewController : UIViewController
    {
        WeakReference weakReference;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Main";

            var mainView = new UIView
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.White
            };
            View = mainView;

            var _galleryButton = new UIButton
            {
                Frame = new CGRect(mainView.Frame.Width / 2 - 100, 120, 200, 44)
            };
            _galleryButton.SetTitle("Go to gallery", UIControlState.Normal);
            _galleryButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);

            _galleryButton.TouchUpInside += GalleryButton_TouchUpInside;

            mainView.AddSubview(_galleryButton);


            var _eventsButton = new UIButton
            {
                Frame = new CGRect(mainView.Frame.Width / 2 - 100, 300, 200, 44)
            };
            _eventsButton.SetTitle("Go to evil button", UIControlState.Normal);
            _eventsButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);

            _eventsButton.TouchUpInside += _eventsButton_TouchUpInside; ;

            mainView.AddSubview(_eventsButton);

            var _checkRefButton = new UIButton
            {
                Frame = new CGRect(mainView.Frame.Width / 2 - 100, 450, 200, 44)
            };
            _checkRefButton.SetTitle("Is reference alive?", UIControlState.Normal);
            _checkRefButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);

            _checkRefButton.TouchUpInside += _checkRefButton_TouchUpInside;

            mainView.AddSubview(_checkRefButton);
        }

        private void _GCButton_TouchUpInside(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        void GalleryButton_TouchUpInside(object sender, EventArgs e)
        {
            var _images = new List<string>
            {
                "Xamarin",
                "Microsoft"
            };

            NavigationController.PushViewController(new GalleryViewController(_images), true);
        }

        void _eventsButton_TouchUpInside(object sender, EventArgs e)
        {
            UIStoryboard storyboard = UIStoryboard.FromName("MyStoryboard", null);

            var controller = storyboard.InstantiateViewController("EventsViewController");

            weakReference = new WeakReference(controller);

            NavigationController.PushViewController(controller, true);
        }

        void _checkRefButton_TouchUpInside(object sender, EventArgs e)
        {
            CheckIsReferenceAlive();
        }

        void CheckIsReferenceAlive()
        {
            Debug.WriteLine($"Reference is {(weakReference?.IsAlive ?? false ? "" : "NOT")} alive!");
        }
    }
}
