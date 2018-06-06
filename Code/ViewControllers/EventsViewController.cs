using Foundation;
using System;
using System.Diagnostics;
using System.Threading;
using UIKit;

namespace Memory.iOS
{
    public partial class EventsViewController : UIViewController
    {
        static int InstanceCounter;

        NSObject orientationNotificationToken = null;

        public EventsViewController(IntPtr handle) : base(handle)
        {
            Interlocked.Increment(ref InstanceCounter);
            Debug.WriteLine($"Number of instances: {InstanceCounter}");
        }

        private void OrientationChanged(NSNotification obj)
        {
            //OrientationChanged;
        }

        public override void ViewDidAppear(bool animated)
        {
            EvilButton.TouchUpInside += EvilButton_TouchUpInside;
            orientationNotificationToken = NSNotificationCenter.DefaultCenter.AddObserver(UIDevice.OrientationDidChangeNotification, OrientationChanged);

            base.ViewDidAppear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            EvilButton.TouchUpInside -= EvilButton_TouchUpInside;
            NSNotificationCenter.DefaultCenter.RemoveObserver(orientationNotificationToken);

            base.ViewDidDisappear(animated);
        }

        void EvilButton_TouchUpInside(object sender, EventArgs e)
        {
            Print();
        }

        void Print()
        {
            Debug.WriteLine("Hello Techorama");
        }

#if DEBUG
        ~EventsViewController()
        {
            Interlocked.Decrement(ref InstanceCounter);
            Debug.WriteLine($"Finalizing... Number of Instances: {InstanceCounter}");
        }
#endif
    }
}