using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinTest2.objects;

namespace XamarinTest2.controls
{
    class VideoView : View
    {
        public static readonly BindableProperty VideoProperty = BindableProperty.Create(
            propertyName:"Video",
            returnType: typeof(VideoInformation),
            declaringType: typeof(VideoView),
            defaultValue: new VideoInformation()
            );

        public VideoInformation Video
        {
            get { return (VideoInformation)GetValue(VideoProperty);  }
            set { SetValue(VideoProperty, value); }
        }
    }
}
