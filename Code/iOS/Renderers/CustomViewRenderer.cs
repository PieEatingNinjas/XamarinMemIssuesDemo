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

        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                view = new UIView(new RectangleF(0, 0, 100, 100));
                view.BackgroundColor = UIColor.Red;
                NSNotificationCenter.DefaultCenter.AddObserver(UIDevice.BatteryLevelDidChangeNotification, OrientationChanged);
                SetNativeControl(view);
            }
        }

        private void OrientationChanged(NSNotification obj)
        {
            //
        }
    }
}
