using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FloatingLabelEntry.ExtendedControls;
using FloatingLabelEntry.Android.ExtendedControls;
using Android.Graphics.Drawables;


[assembly: ExportRenderer(typeof(RoundedCornerView), typeof(RoundedCornerViewRenderer))]

namespace FloatingLabelEntry.Android.ExtendedControls
{
	public class RoundedCornerViewRenderer:FrameRenderer
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Register() { }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnElementChanged (ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement==null && e.NewElement!=null) {
				var shape =  new GradientDrawable();
				shape.SetCornerRadius(((RoundedCornerView)e.NewElement).CornerRadius);
				shape.SetColor (Xamarin.Forms.Color.Transparent.ToAndroid ().ToArgb ());
				shape.SetStroke ((int)((RoundedCornerView)e.NewElement).BorderThickness, ((RoundedCornerView)e.NewElement).BorderColor.ToAndroid ());
				this.SetBackground(shape);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName==RoundedCornerView.BorderColorProperty.PropertyName || e.PropertyName==RoundedCornerView.BorderThicknessProperty.PropertyName) {
				var shape =  new GradientDrawable();
				shape.SetCornerRadius(((RoundedCornerView)Element).CornerRadius);
				shape.SetColor (Xamarin.Forms.Color.Transparent.ToAndroid ().ToArgb ());
				shape.SetStroke ((int)((RoundedCornerView)Element).BorderThickness, ((RoundedCornerView)Element).BorderColor.ToAndroid ());
				this.SetBackground(shape);
			}
		}
	}
}

