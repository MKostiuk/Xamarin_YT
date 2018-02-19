package md50d3d580d08504a2a1a6d250c4c8a3f6c;


public class VideoViewSavedState
	extends android.view.View.BaseSavedState
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_writeToParcel:(Landroid/os/Parcel;I)V:GetWriteToParcel_Landroid_os_Parcel_IHandler\n" +
			"";
		mono.android.Runtime.register ("Octane.Xamarin.Forms.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xamarin.Forms.VideoPlayer.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", VideoViewSavedState.class, __md_methods);
	}


	public VideoViewSavedState (android.os.Parcel p0)
	{
		super (p0);
		if (getClass () == VideoViewSavedState.class)
			mono.android.TypeManager.Activate ("Octane.Xamarin.Forms.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xamarin.Forms.VideoPlayer.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Parcel, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public VideoViewSavedState (android.os.Parcel p0, java.lang.ClassLoader p1)
	{
		super (p0, p1);
		if (getClass () == VideoViewSavedState.class)
			mono.android.TypeManager.Activate ("Octane.Xamarin.Forms.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xamarin.Forms.VideoPlayer.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Parcel, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.ClassLoader, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public VideoViewSavedState (android.os.Parcelable p0)
	{
		super (p0);
		if (getClass () == VideoViewSavedState.class)
			mono.android.TypeManager.Activate ("Octane.Xamarin.Forms.VideoPlayer.Android.Views.View.VideoViewSavedState, Octane.Xamarin.Forms.VideoPlayer.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.IParcelable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void writeToParcel (android.os.Parcel p0, int p1)
	{
		n_writeToParcel (p0, p1);
	}

	private native void n_writeToParcel (android.os.Parcel p0, int p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
