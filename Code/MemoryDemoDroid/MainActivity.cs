using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Net.Http;
using System;

namespace MemoryDemoDroid
{
    [Activity(Label = "MemoryDemoDroid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        string[] urls = new string[]
        {
            "http://d1wfiv6sf8d64f.cloudfront.net/static/pc/img/visual_main.jpg",
            "https://www.windowscentral.com/sites/wpcentral.com/files/styles/xlarge/public/field/image/2018/01/pubg%20screen.jpg?itok=oJpxG3Lx",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Very_Large_Array%2C_2012.jpg/1600px-Very_Large_Array%2C_2012.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Very_Large_Telescope_Ready_for_Action_%28ESO%29.jpg/1600px-Very_Large_Telescope_Ready_for_Action_%28ESO%29.jpg",
            "https://qz.com/wp-content/uploads/2017/10/pubg-poster-e1509349216289.jpg?quality=80&strip=all&w=3200",
            "https://res.cloudinary.com/lmn/image/upload/e_sharpen:100/f_auto,fl_lossy,q_auto/v1/gameskinnyc/p/u/b/pubg-compressed-ea4cb.jpg",
            "https://cdn.wccftech.com/wp-content/uploads/2017/09/playerunknowns-battlegrounds-update-2.jpg",
            "https://dontfeedthegamers.com/wp-content/uploads/2018/03/IMG_2523.jpg",
            "https://news.xbox.com/en-us/wp-content/uploads/Xbox_PUBG_16x9_INFOG_FINAL_r1t4_bm.png",
            "https://i2.wp.com/www.infogranny.com/wp-content/uploads/2018/02/PUBG-Coming-up-with-a-3rd-Map-1.jpg",
            "https://cdn0.tnwcdn.com/wp-content/blogs.dir/1/files/2018/03/PUBG-Mobile-796x419.jpg",
            "https://gameplay.tips/uploads/posts/2018-03/1521750829_6.jpg",
            "https://gameplay.tips/uploads/posts/2018-03/1521750792_2.jpg",
            "https://gameplay.tips/uploads/posts/2018-03/1521750823_1.jpg",

        };

        int[] views = new int[]
        {
            Resource.Id.imageview0,
            Resource.Id.imageview1,
            Resource.Id.imageview2,
            Resource.Id.imageview3,
            Resource.Id.imageview4,
            Resource.Id.imageview5,
            Resource.Id.imageview6,
            Resource.Id.imageview7,
            Resource.Id.imageview8,
            Resource.Id.imageview9,
            Resource.Id.imageview10,
            Resource.Id.imageview11,
            Resource.Id.imageview12,
            Resource.Id.imageview13
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += Load;

            Button button2 = FindViewById<Button>(Resource.Id.myButton2);
            button2.Click += LoadOptimized;

            System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;

        }

        async void Load(object sender, System.EventArgs e)
        {
            HttpClient client = new HttpClient();
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    var url = urls[i];

                    var stream = await client.GetStreamAsync(url);

                    var bitmap = await BitmapFactory.DecodeStreamAsync(stream);

                    var small = Bitmap.CreateScaledBitmap(bitmap, 200, 200, false);

                    var imageView = FindViewById<ImageView>(views[i]);

                    imageView.SetImageBitmap(small);
                }
                catch (Exception)
                {
                    // ¯\_(ツ)_/¯
                }
            }
        }

        async void LoadOptimized(object sender, System.EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < urls.Length; i++)
                {
                    try
                    {
                        var url = urls[i];

                        using (var stream = await client.GetStreamAsync(url))
                        {
                            using (var bitmap = await BitmapFactory.DecodeStreamAsync(stream))
                            {

                                using (var small = Bitmap.CreateScaledBitmap(bitmap, 200, 200, false))
                                {
                                    var imageView = FindViewById<ImageView>(views[i]);

                                    imageView.SetImageBitmap(small);
                                }
                                bitmap.Recycle();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // ¯\_(ツ)_/¯
                    }
                }
            }
            GC.Collect();
        }
    }
}

