using UIKit;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;

namespace Memory.iOS.ViewControllers
{
    public class GalleryViewController : UIViewController
    {
        List<string> _images;
        int _currentImageIndex; 

        public GalleryViewController(List<string> images)
        {
            _images = images;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Gallery";

            var mainView = new UIView
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.White
            };
            View = mainView;
            View.AddSubview(new GalleryImageView(this));
        }

		public void ShowNextImage(GalleryImageView imgView)
        {
            imgView.LoadImage(_images[_currentImageIndex]);

            _currentImageIndex++;

            if (_currentImageIndex >= _images.Count)
                _currentImageIndex = 0;
        }
	}



    public class GalleryImageView : UIView
    {
        GalleryViewController _galleryViewController;

        public GalleryImageView(GalleryViewController galleryViewController)
        {
            _galleryViewController = galleryViewController;
            UserInteractionEnabled = true;
        }

		public override void LayoutSubviews()
		{
            Frame = Superview.Frame;
            var imageSize = Superview.Frame.Width - 100;

            var _imageView = new UIImageView
            {
                Frame = new CGRect(Superview.Frame.Width / 2 - (imageSize / 2), Superview.Frame.Height / 2 - (imageSize / 2), imageSize, imageSize),
                BackgroundColor = UIColor.Black,
                ContentMode = UIViewContentMode.ScaleAspectFit,
                UserInteractionEnabled = true
            };

            AddSubview(_imageView);
            ShowNextImage();

          base.LayoutSubviews();
		}

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            ShowNextImage();
        }

		void ShowNextImage()
        {
            _galleryViewController.ShowNextImage(this);
        }

        public void LoadImage(string imageName)
        {
           (Subviews[0] as UIImageView).Image = UIImage.FromFile(imageName);
        }
	}
}
