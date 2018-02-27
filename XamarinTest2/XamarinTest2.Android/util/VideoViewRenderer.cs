
using Android.Content;
using Android.Widget;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinTest2.controls;
using XamarinTest2.objects;
using ARelativeLayout = Android.Widget.RelativeLayout;

[assembly: ExportRenderer(typeof(XamarinTest2.controls.VideoPlayer),
                          typeof(XamarinTest2.Droid.VideoViewRenderer))]
namespace XamarinTest2.Droid
{
   class VideoViewRenderer : ViewRenderer<VideoPlayer, ARelativeLayout>
    {
        VideoView videoView;
        MediaController mediaController;
        bool isPrepared;

        public VideoViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    videoView = new VideoView(Context);
                    ARelativeLayout relativeLayout = new ARelativeLayout(Context);
                    relativeLayout.AddView(videoView);

                    ARelativeLayout.LayoutParams layoutParams = new ARelativeLayout.LayoutParams(
                        LayoutParams.MatchParent,
                        LayoutParams.MatchParent);
                    videoView.LayoutParameters = layoutParams;

                    SetNativeControl(relativeLayout);
                }

                SetSource();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VideoPlayer.VideoProperty.PropertyName)
            {
                SetSource();
            }
        }

        void SetSource()
        {
            bool hasSetSource = false;

            if (Element.Video is VideoInformation)
            {
                string package = Context.PackageName;
                string path = (Element.Video as VideoInformation).Url;

                if (!string.IsNullOrWhiteSpace(path))
                {
                    string filename = Path.GetFileNameWithoutExtension(path).ToLowerInvariant();
                    string uri = "android.resource://" + package + "/raw/" + filename;
                    videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
                    hasSetSource = true;
                }
            }
            if (hasSetSource && Element.AutoPlay)
                videoView.Start();
        }
    }
}