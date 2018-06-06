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
            NSNotificationCenter.DefaultCenter.AddObserver(UIDevice.OrientationDidChangeNotification, OrientationChanged);

            base.ViewDidAppear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
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

        ~EventsViewController()
        {
            Interlocked.Decrement(ref InstanceCounter);
            Debug.WriteLine($"Finalizing... Number of Instances: {InstanceCounter}");
        }
    }
}