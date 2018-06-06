using Foundation;
using UIKit;
using Memory.iOS.ViewControllers;

namespace Memory.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        UIWindow _window;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            var navigationController = new UINavigationController(new MainViewController());

            _window.RootViewController = navigationController;

            _window.MakeKeyAndVisible();

            return true;
        }
    }
}

