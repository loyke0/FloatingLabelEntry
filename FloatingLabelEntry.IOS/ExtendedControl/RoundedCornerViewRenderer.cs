using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FloatingLabelEntry.iOS.ExtendedControl;
using FloatingLabelEntry.ExtendedControl;

[assembly: ExportRenderer(typeof(RoundedCornerView), typeof(RoundedCornerViewRenderer))]

namespace FloatingLabelEntry.iOS.ExtendedControl
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
				Layer.BorderColor = ((RoundedCornerView)e.NewElement).BorderColor.ToCGColor ();
				Layer.BorderWidth = ((RoundedCornerView)e.NewElement).BorderThickness;
				Layer.CornerRadius = ((RoundedCornerView)e.NewElement).CornerRadius;
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
			if (e.PropertyName==RoundedCornerView.BorderColorProperty.PropertyName) {
				Layer.BorderColor = ((RoundedCornerView)Element).BorderColor.ToCGColor ();
			}
			else if (e.PropertyName==RoundedCornerView.BorderThicknessProperty.PropertyName) {
				Layer.BorderWidth = ((RoundedCornerView)Element).BorderThickness;
			}
		}
	}
}

