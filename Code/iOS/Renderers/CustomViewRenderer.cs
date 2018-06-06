using System;
using System.Drawing;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamFormsMemory.CustomControls;
using XamFormsMemory.iOS.Renderers;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomViewRenderer))]
namespace XamFormsMemory.iOS.Renderers
{

    public class CustomViewRenderer : ViewRenderer<CustomView, UIView>
    {
        UIView view;
        NSObject token;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                view = new UIView(new RectangleF(0, 0, 100, 100));
                view.BackgroundColor = UIColor.Red;
                SetNativeControl(view);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
                if (token != null)
                    NSNotificationCenter.DefaultCenter.RemoveObserver(token);
            }
            if (e.NewElement != null)
            {
                //Subscribe
                token = NSNotificationCenter.DefaultCenter.AddObserver(UIDevice.BatteryLevelDidChangeNotification, OrientationChanged);
            }
        }

        private void OrientationChanged(NSNotification obj)
        {
            //
        }
    }
}
