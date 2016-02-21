using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FloatingLabelEntry.ExtendedControls;
using FloatingLabelEntry.Android.ExtendedControls;
using System;
using Android.Graphics;
using Android.Graphics.Drawables;



[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace FloatingLabelEntry.Android.ExtendedControls
{
	public class ExtendedLabelRenderer:LabelRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement==null && e.NewElement!=null) {
				var label = e.NewElement as ExtendedLabel;
				this.SetFont (label);
				this.SetPadding (0, 0, 0, 0);
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
		public static void Register() { }

		private void SetFont (ExtendedLabel label){
			string filename = label.FontName;
			if (!String.IsNullOrWhiteSpace(filename)) {
				//if no extension given then assume and add .ttf
				if(filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4)
				{
					filename = string.Format("{0}.ttf", filename);
				}
				Control.Typeface = TrySetFont(filename);
			} else {
				Control.Typeface = Typeface.Default;
			}
		}

		/// <summary>
		/// Tries the set font.
		/// </summary>
		/// <param name="fontName">Name of the font.</param>
		/// <returns>Typeface.</returns>
		private Typeface TrySetFont(string fontName)
		{
			try
			{                
				return Typeface.CreateFromAsset(Context.Assets, "Fonts/" + fontName);
			} catch(Exception ex)
			{
				Console.WriteLine("not found in assets. Exception: {0}", ex);
				try
				{
					return Typeface.CreateFromFile("Fonts/" + fontName);
				} catch(Exception ex1)
				{
					Console.WriteLine("not found by file. Exception: {0}", ex1);

					return Typeface.Default;
				}
			}
		}
	}
}

