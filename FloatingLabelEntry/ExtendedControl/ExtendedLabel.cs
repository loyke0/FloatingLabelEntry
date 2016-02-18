using System;
using Xamarin.Forms;

namespace FloatingLabelEntry.ExtendedControls
{
	public class ExtendedLabel:Label
	{
		/// <summary>
		/// The FontName Property
		/// </summary>
		public static readonly BindableProperty FontNameProperty =BindableProperty.Create("FontName", typeof(string), typeof(ExtendedLabel), null);

		/// <summary>
		/// Get or Set the Name of the embedded font to be used
		/// </summary>
		/// <remarks>
		/// In order to work on all platforms, the font name must be the same as the name of the file containing it.
		/// Refer to doc for more info on how to set custom font.
		/// </remarks>
		public String FontName {
			get{ return (String) GetValue(FontNameProperty) ;}
			set{ SetValue (FontNameProperty, value); }
		}
	}
}

