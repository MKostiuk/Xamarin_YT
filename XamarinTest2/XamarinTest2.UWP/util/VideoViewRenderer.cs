using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
using XamarinTest2.controls;
using XamarinTest2.objects;
using XamarinTest2.util;
using XamarinTest2.UWP;

[assembly: ExportRenderer(typeof(VideoPlayer), typeof(VideoViewRenderer))]
namespace XamarinTest2.UWP
{
    class VideoViewRenderer : ViewRenderer<VideoPlayer, MediaElement>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    MediaElement mediaElement = new MediaElement();
                    SetNativeControl(mediaElement);
                    mediaElement.CurrentStateChanged += OnMediaElementCurrentStateChanged;
                }

                SetSource();
                SetAutoplay();
                Control.AreTransportControlsEnabled = false;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VideoPlayer.VideoProperty.PropertyName)
            {
                SetSource();
            }
            else if (e.PropertyName == VideoPlayer.AutoPlayProperty.PropertyName)
            {
                SetAutoplay();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                Control.CurrentStateChanged -= OnMediaElementCurrentStateChanged;
            }
            base.Dispose(disposing);
        }

        void OnMediaElementCurrentStateChanged(object sender, RoutedEventArgs args)
        {
            VideoStatus videoStatus = VideoStatus.NotReady;

            switch (Control.CurrentState)
            {
                case MediaElementState.Playing:
                    videoStatus = VideoStatus.Playing;
                    break;
                case MediaElementState.Paused:
                case MediaElementState.Stopped:
                    videoStatus = VideoStatus.Paused;
                    break;
            }
            // ((IVideoPlayerController)Element).Status = videoStatus;
        }

        void SetAutoplay()
        {
            Control.AutoPlay = Element.AutoPlay;
        }

        void SetSource()
        {
            string path = "ms-appx:///" + (Element.Video as VideoInformation).Url;

            if (!String.IsNullOrWhiteSpace(path))
            {
                Control.Source = new Uri(path);
                Control.Play();
            }
        }

        void SetAreTransportControlsEnabled()
        {
            Control.AreTransportControlsEnabled = Element.AreTransportControlEnabled;
        }
    }
}
