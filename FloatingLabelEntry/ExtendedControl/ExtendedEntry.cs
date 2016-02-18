using System;
using Xamarin.Forms;
using FloatingLabelEntry.Enumerations;

namespace FloatingLabelEntry.ExtendedControls
{
	public class ExtendedEntry:Entry
	{
		/// <summary>
		/// The CustomKeyboard Property
		/// </summary>
		public static readonly BindableProperty CustomKeyboardProperty =BindableProperty.Create("CustomKeyboard", typeof(CustomKeyboardEnum), typeof(ExtendedEntry), default(CustomKeyboardEnum));

		/// <summary>
		/// Get or Set the CustomKeyboard
		/// </summary>
		public CustomKeyboardEnum CustomKeyboard {
			get{ return (CustomKeyboardEnum) GetValue(CustomKeyboardProperty) ;}
			set{ SetValue (CustomKeyboardProperty, value); }
		}

		/// <summary>
		/// The FontName Property
		/// </summary>
		public static readonly BindableProperty FontNameProperty =BindableProperty.Create("FontName", typeof(string), typeof(ExtendedEntry), null);

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

