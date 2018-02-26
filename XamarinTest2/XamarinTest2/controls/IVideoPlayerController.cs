using System;
using System.Collections.Generic;
using System.Text;
using XamarinTest2.util;

namespace XamarinTest2.controls
{
    public interface IVideoPlayerController
    {
        VideoStatus Status { get; set; }

        TimeSpan Duration { get; set; }
    }
}
