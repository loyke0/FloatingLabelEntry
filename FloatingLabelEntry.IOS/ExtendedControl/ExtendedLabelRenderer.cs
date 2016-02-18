using System;
using Xamarin.Forms;
using FloatingLabelEntry.ExtendedControls;
using FloatingLabelEntry.iOS.ExtendedControls;
using Xamarin.Forms.Platform.iOS;
using UIKit;


[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]

namespace FloatingLabelEntry.iOS.ExtendedControls
{
	public class ExtendedLabelRenderer:LabelRenderer
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Register() { }

		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement==null && e.NewElement!=null) {
				var label = e.NewElement as ExtendedLabel;
				this.SetFont (label);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var label = Element as ExtendedLabel;
			if (e.PropertyName==ExtendedLabel.FontNameProperty.PropertyName) {
				SetFont (label);
			}
		}

		private void SetFont (ExtendedLabel label){
			if (!String.IsNullOrWhiteSpace(label.FontName)) {
				var font = UIFont.FromName (label.FontName, (nfloat)label.FontSize);
				if (font != null)
				{
					this.Control.Font = font;
				}
			} else {
				var tmp = Font.Default.ToUIFont ().WithSize ((nfloat)label.FontSize);
				this.Control.Font = Font.Default.ToUIFont().WithSize((nfloat)label.FontSize);
			}
		}
	}
}

