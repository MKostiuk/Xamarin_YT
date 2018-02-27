using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinTest2.objects;

namespace XamarinTest2.controls
{
    class VideoPlayer : View
    {

        //Source VideoInformation
        public static readonly BindableProperty VideoProperty = BindableProperty.Create(
            propertyName:"Video",
            returnType: typeof(VideoInformation),
            declaringType: typeof(VideoPlayer),
            defaultValue: new VideoInformation()
            );

        public VideoInformation Video
        {
            get { return (VideoInformation)GetValue(VideoProperty);  }
            set { SetValue(VideoProperty, value); }
        }

        //AutoPlay Property
        public static readonly BindableProperty AutoPlayProperty = BindableProperty.Create(
            propertyName:"AutoPlay",
            returnType: typeof(Boolean),
            declaringType: typeof(VideoPlayer),
            defaultValue : true
            );

        public bool AutoPlay
        {
            get { return (bool)GetValue(AutoPlayProperty); }
            set { SetValue(AutoPlayProperty, value); }
        }

        //AreTransportControlEnabled Property
        public static readonly BindableProperty AreTransportControlProperty = BindableProperty.Create(
            propertyName:"AreTransportControlProperty",
            returnType: typeof(Boolean),
            declaringType: typeof(VideoPlayer),
            defaultValue: false
            );

        public bool AreTransportControlEnabled
        {
            get { return (bool)GetValue(AreTransportControlProperty); }
            set { SetValue(AreTransportControlProperty, value); }
        }
    }
}
