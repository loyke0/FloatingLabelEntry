using System;
using Xamarin.Forms;
using FloatingLabelEntry.Enumerations;

namespace FloatingLabelEntry.ExtendedControl
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
	}
}

