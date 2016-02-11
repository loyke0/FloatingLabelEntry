using System;
using Xamarin.Forms;
using System.Globalization;
using FloatingLabelEntry.Base;
using FloatingLabelEntry.Enumerations;
using System.Text.RegularExpressions;

namespace FloatingLabelEntry.Demo
{
	public class PasswordFloatingLabelEntry:FloatingLabelEntryBase
	{
		public PasswordFloatingLabelEntry ()
		{
			this.InputValidator = InputValidatorDelegate;
			this.MustValidate = true;
			this.IsPassword = true;
			this.LabelText = "Test your password";
			var validEntryStateProperties = new FloatingLabelEntryStateProperties {
				IconSource = ImageSource.FromFile ("ValidationIcons/ValidIcon.png"),
				BorderColor =Color.Green,
				BorderThickness=3,
				InfoMessage="Password safe",
			};

			var errorEntryStateProperties = new FloatingLabelEntryStateProperties {
				IconSource = ImageSource.FromFile ("ValidationIcons/ErrorIcon.png"),
				BorderColor=Color.Red,
				BorderThickness=3,
				InfoMessage= "Password very weak.",
			};

			var warningEntryStateProperties = new FloatingLabelEntryStateProperties {
				IconSource = ImageSource.FromFile ("ValidationIcons/WarningIcon.png"),
				BorderColor=Color.FromHex("FFA500"),
				BorderThickness=3,
				InfoMessage= "Password strength average.",
			};

			var normalEntryStateProperties = new FloatingLabelEntryStateProperties {
				BorderColor=Color.FromHex("4b9be0"),
				BorderThickness=3,
			};
				
			this.AddPropertiesForState (validEntryStateProperties, FloatingLabelEntryState.Valid);
			this.AddPropertiesForState (warningEntryStateProperties, FloatingLabelEntryState.Warning);
			this.AddPropertiesForState (errorEntryStateProperties, FloatingLabelEntryState.Error);
			this.AddPropertiesForState (normalEntryStateProperties, FloatingLabelEntryState.Neutral);

			this.State = FloatingLabelEntryState.Neutral;
		}

		public FloatingLabelEntryState InputValidatorDelegate(string inputValue){
			if (inputValue.Length<6) {
				return FloatingLabelEntryState.Error;
			}
			else if (inputValue.Length<8) {
				return FloatingLabelEntryState.Warning;
			}
			return FloatingLabelEntryState.Valid;
		}
	}
}

