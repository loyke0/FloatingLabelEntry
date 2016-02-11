using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using System.Drawing;
using FloatingLabelEntry.ExtendedControl;
using FloatingLabelEntry.Enumerations;
using FloatingLabelEntry.iOS.ExtendedControl;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]

namespace FloatingLabelEntry.iOS.ExtendedControl
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
			if (this.Control!=null && e.NewElement!=null) {
				var entry = e.NewElement as ExtendedEntry;
				this.SetKeyboard (entry.CustomKeyboard);
				this.Control.AutocorrectionType = UITextAutocorrectionType.No;
				this.Control.SpellCheckingType = UITextSpellCheckingType.No;
				this.Control.BorderStyle = UITextBorderStyle.None;
				LayoutSubviews();
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			var entry = Element as ExtendedEntry;
			if (e.PropertyName == ExtendedEntry.CustomKeyboardProperty.PropertyName) {
				SetKeyboard (entry.CustomKeyboard);
			}
		}
			
		private void SetKeyboard(CustomKeyboardEnum keyboard){
			switch (keyboard) {
			case CustomKeyboardEnum.Chat:
				Control.ApplyKeyboard (Keyboard.Chat);
				SetNumericToolbar (false);
				break;

			case CustomKeyboardEnum.Email:
				Control.ApplyKeyboard (Keyboard.Email);
				SetNumericToolbar (false); 
				break;

			case CustomKeyboardEnum.EmailAndNumeric:
				Control.ApplyKeyboard (Keyboard.Email);
				SetNumericToolbar (true);
				break;

			case CustomKeyboardEnum.Numeric:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Numeric);
				break;

			case CustomKeyboardEnum.Phone:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Telephone);
				break;

			case CustomKeyboardEnum.Text:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Text);
				break;

			case CustomKeyboardEnum.Url:
				SetNumericToolbar (false);
				Control.ApplyKeyboard (Keyboard.Url);
				break;

			default:
				break;
			}
		}

		private void SetNumericToolbar(bool isSet) {
			if (isSet) {
				UIToolbar toolbar = new UIToolbar (new RectangleF(0.0f, 0.0f, 10.0f, 44.0f));
				toolbar.Items = new UIBarButtonItem[]{
					new UIBarButtonItem("1",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("2",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("3",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("4",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("5",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("6",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("7",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("8",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("9",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
					new UIBarButtonItem("0",
						UIBarButtonItemStyle.Plain, AddBarButtonText),
				};
				Control.InputAccessoryView = toolbar;
			} else {
				Control.InputAccessoryView = null;
			}
		}

		public void AddBarButtonText(object sender, EventArgs e)
		{
			var barButtonItem = sender as UIBarButtonItem;
			if (barButtonItem != null)
				Control.Text += barButtonItem.Title;
		}


	}
}

