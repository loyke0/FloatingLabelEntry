using System;
using Xamarin.Forms;
using FloatingLabelEntry.ExtendedControls;
using FloatingLabelEntry.Android.ExtendedControls;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using FloatingLabelEntry.Enumerations;
using Android.Text;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace FloatingLabelEntry.Android.ExtendedControls
{
	public class ExtendedEntryRenderer:EntryRenderer
	{
		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Register() { }

		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null && e.NewElement != null) {
				var entry = e.NewElement as ExtendedEntry;
				var shape =  new GradientDrawable();
				shape.SetColor (Xamarin.Forms.Color.Transparent.ToAndroid ().ToArgb ());
				shape.SetStroke (0, Xamarin.Forms.Color.Transparent.ToAndroid ());
				this.Control.SetBackground(shape);
				this.Control.SetHintTextColor (Xamarin.Forms.Color.Gray.ToAndroid());
				this.Control.SetTextColor (Xamarin.Forms.Color.Black.ToAndroid());
				this.SetKeyboard (entry.CustomKeyboard);
				this.SetFont (entry);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var entry = Element as ExtendedEntry;
			if (e.PropertyName == ExtendedEntry.CustomKeyboardProperty.PropertyName) {
				SetKeyboard (entry.CustomKeyboard);
			}
			else if (e.PropertyName==ExtendedEntry.FontNameProperty.PropertyName) {
				SetFont (entry);
			}
		}


		private void SetFont (ExtendedEntry entry){
			string filename = entry.FontName;
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

		private void SetKeyboard(CustomKeyboardEnum keyboard){
			switch (keyboard) {
			case CustomKeyboardEnum.Chat:
				Control.InputType = InputTypes.ClassText;
				break;

			case CustomKeyboardEnum.Email:
				Control.InputType = InputTypes.TextVariationEmailAddress;
				break;

			case CustomKeyboardEnum.EmailAndNumeric:
				Control.InputType = InputTypes.ClassPhone | InputTypes.TextVariationEmailAddress;
				break;

			case CustomKeyboardEnum.Numeric:
				Control.InputType = InputTypes.ClassNumber;
				break;

			case CustomKeyboardEnum.Phone:
				Control.InputType = InputTypes.ClassPhone;
				break;

			case CustomKeyboardEnum.Text:
				Control.InputType = InputTypes.ClassText;
				break;
				 
			case CustomKeyboardEnum.Url:
				Control.InputType = InputTypes.TextVariationUri;
				break;

			default:
				break;
			}
		}
	}
}

