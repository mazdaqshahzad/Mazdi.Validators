using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mazdi.Validators
{
    /// <summary>
    /// Main Class for Handling Validation Logic.
    /// </summary>
    public static class ValidationService
    {

        /// <summary>
        /// Main Method for handling Validation Logic
        /// </summary>
        /// <param name="list">List of Data Properties</param>
        /// <returns>Validation Response: It contains status code and list of error messages (if any)</returns>
        public static ValidationResponse Validate(List<ValidationModel> list)
        {
            ValidationResponse validationResponse = new ValidationResponse() { Messages = new List<string>() };

            list.ForEach(item =>
            {
                switch (item.ValidationType)
                {
                    case ValidationType.Email:
                        {
                            string message = ValidateEmail(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }

                    case ValidationType.Name:
                        {
                            string message = ValidateName(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }

                    case ValidationType.Address:
                        {
                            string message = ValidateAddress(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }

                    case ValidationType.Title:
                        {
                            string message = ValidateTitle(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }

                    case ValidationType.GeneralString:
                        {
                            string message = ValidateSimpleString(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }

                    case ValidationType.Age:
                        {
                            string message = ValidateAge(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }

                    case ValidationType.Numerics:
                        {
                            string message = ValidateNumerics(item);
                            if (!string.IsNullOrEmpty(message))
                                validationResponse.Messages.Add(message);
                            break;
                        }
                }
            });

            validationResponse.StatusCode = validationResponse.Messages?.Count > 0 ? 400 : 200;
            return validationResponse;
        }

        private static string ValidateEmail(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Email Address" : model.PropertyName;
            string message;

            try
            {
                if (string.IsNullOrEmpty(model.PropertyValue as string))
                    message = "Invalid " + model.PropertyName;

                else if (model.Minimum.HasValue && (model.PropertyValue as string).Length < model.Minimum)
                    message = model.PropertyName + " minimum length should be " + model.Minimum + " Characters.";

                else if (model.Maximum.HasValue && (model.PropertyValue as string).Length > model.Maximum)
                    message = model.PropertyName + " maximum length should be " + model.Maximum + " Characters.";

                else
                {
                    bool isValidEmail = Regex.IsMatch(model.PropertyValue as string, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (!isValidEmail)
                        message = "Invalid " + model.PropertyName;
                    else
                        message = string.Empty;
                }
            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }

        private static string ValidateName(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Name" : model.PropertyName;

            string message;

            try
            {
                if (string.IsNullOrEmpty(model.PropertyValue as string))
                    message = "Invalid " + model.PropertyName;

                else if (model.Minimum.HasValue && (model.PropertyValue as string).Length < model.Minimum)
                    message = model.PropertyName + " minimum length should be " + model.Minimum + " Characters.";

                else if (model.Maximum.HasValue && (model.PropertyValue as string).Length > model.Maximum)
                    message = model.PropertyName + " maximum length should be " + model.Maximum + " Characters.";

                else
                    message = string.Empty;
            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }

        private static string ValidateTitle(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Title" : model.PropertyName;

            string message;

            try
            {
                if (string.IsNullOrEmpty(model.PropertyValue as string))
                    message = "Invalid " + model.PropertyName;

                else if (model.Minimum.HasValue && (model.PropertyValue as string).Length < model.Minimum)
                    message = model.PropertyName + " minimum length should be " + model.Minimum + " Characters.";

                else if (model.Maximum.HasValue && (model.PropertyValue as string).Length > model.Maximum)
                    message = model.PropertyName + " maximum length should be " + model.Maximum + " Characters.";

                else
                    message = string.Empty;
            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }

        private static string ValidateAddress(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Address" : model.PropertyName;

            string message;

            try
            {
                if (string.IsNullOrEmpty(model.PropertyValue as string))
                    message = "Invalid " + model.PropertyName;

                else if (model.Minimum.HasValue && (model.PropertyValue as string).Length < model.Minimum)
                    message = model.PropertyName + " minimum length should be " + model.Minimum + " Characters.";

                else if (model.Maximum.HasValue && (model.PropertyValue as string).Length > model.Maximum)
                    message = model.PropertyName + " maximum length should be " + model.Maximum + " Characters.";

                else
                    message = string.Empty;
            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }

        private static string ValidateSimpleString(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Value" : model.PropertyName;
            string message;

            try
            {
                if (string.IsNullOrEmpty(model.PropertyValue as string))
                    message = "Invalid " + model.PropertyName;

                else if (model.Minimum.HasValue && (model.PropertyValue as string).Length < model.Minimum)
                    message = model.PropertyName + " minimum length should be " + model.Minimum + " Characters.";

                else if (model.Maximum.HasValue && (model.PropertyValue as string).Length > model.Maximum)
                    message = model.PropertyName + " maximum length should be " + model.Maximum + " Characters.";

                else
                    message = string.Empty;
            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }

        private static string ValidateAge(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Age" : model.PropertyName;

            string message;

            try
            {

                if (model.PropertyValue == null || string.IsNullOrEmpty(Convert.ToString(model.PropertyValue)))
                    message = "Invalid " + model.PropertyName;

                else if (model.Minimum.HasValue && Convert.ToInt32(model.PropertyValue) < model.Minimum)
                    message = "Minimum " + model.PropertyName + " should be " + model.Minimum;

                else if (model.Maximum.HasValue && Convert.ToInt32(model.PropertyValue) > model.Maximum)
                    message = "Maximum " + model.PropertyName + " should be " + model.Maximum;

                else
                    message = string.Empty;

            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }
        private static string ValidateNumerics(ValidationModel model)
        {
            model.PropertyName = string.IsNullOrEmpty(model.PropertyName) ? "Value" : model.PropertyName;

            string message = string.Empty;


            try
            {
                if (model.PropertyValue == null || string.IsNullOrEmpty(Convert.ToString(model.PropertyValue)))
                    message = model.PropertyName + " cannot be Null.";

                else if (model.Minimum.HasValue && model.Maximum.HasValue && Convert.ToInt32(model.PropertyValue) < model.Minimum && Convert.ToInt32(model.PropertyValue) > model.Maximum)
                    message = model.PropertyName + " should be between " + model.Minimum + " and " + model.Maximum;

                else if (model.Minimum.HasValue && Convert.ToInt32(model.PropertyValue) < model.Minimum)
                    message = "Minimum " + model.PropertyName + " should be " + model.Minimum;

                else if (model.Maximum.HasValue && Convert.ToInt32(model.PropertyValue) > model.Maximum)
                    message = "Maximum " + model.PropertyName + " should be " + model.Maximum;

                else if ((model.PropertyValue is float || model.PropertyValue is double || model.PropertyValue is decimal) && model.DecimalPlaceLimit.HasValue)
                {
                    if (Convert.ToString(model.PropertyValue).Contains("."))
                    {
                        var decimalLength = Convert.ToString(model.PropertyValue).Split('.')[1].Length;
                        if (decimalLength != model.DecimalPlaceLimit)
                            message = model.PropertyName + " should be upto " + model.DecimalPlaceLimit + " decimal places.";
                    }
                }

            }
            catch (Exception)
            {
                message = "Invalid " + model.PropertyName;
            }

            message = string.IsNullOrEmpty(model.CustomMessage) ? message : model.CustomMessage;
            return message;
        }
    }
}
