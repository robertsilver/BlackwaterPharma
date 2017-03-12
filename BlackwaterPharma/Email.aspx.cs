using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Email : System.Web.UI.Page
{
    private enum FieldContainingError
    {
        Address1 = 0,
        Address2 = 1,
        City = 2,
        County = 3,
        Postcode = 4,
        Telephone = 5,
        FirstName = 6,
        LastName = 7,
        PatientEmail = 8,
        Prescription = 9,
        IncorrectEmailFormat = 10,
        /// <summary>
        /// Set to 99 in case other fields are introduced
        /// </summary>
        NoError = 99
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        this.setLabelFontsToBlack();

        #region Check all fields contain safe values
        FieldContainingError fieldError = FieldContainingError.NoError;

        fieldError = this.checkUserEntry();

        if (FieldContainingError.NoError != fieldError)
        {
            this.setAppropriateErrorText(fieldError);
            return;
        }

        this.lblError.Visible = false;
        this.lblUnsafeValues.Visible = false;
        #endregion Check all fields contain safe values

        #region Build up the values of the tags and their replacement values
        string address2 = ((string.Empty == this.txtAddress2.Text) ? string.Empty : this.txtAddress2.Text.Substring(0, 1).ToUpper() + this.txtAddress2.Text.Substring(1).ToLower());
        string[] args = new string[30] 
                        { 
                            "Mandatory", "<FName>", this.txtFName.Text.Substring(0, 1).ToUpper() + this.txtFName.Text.Substring(1).ToLower(),
                            "Mandatory", "<LName>", this.txtLName.Text.Substring(0, 1).ToUpper() + this.txtLName.Text.Substring(1).ToLower(),
                            "Mandatory", "<Address1>", this.txtAddress1.Text.Substring(0, 1).ToUpper() + this.txtAddress1.Text.Substring(1).ToLower(),
                            "Optional", "<Address2>", address2,
                            "Mandatory", "<City>", this.txtCity.Text.Substring(0, 1).ToUpper() + this.txtCity.Text.Substring(1).ToLower(),
                            "Mandatory", "<County>", this.txtCounty.Text.Substring(0, 1).ToUpper() + this.txtCounty.Text.Substring(1).ToLower(),
                            "Mandatory", "<PCode>", this.txtPCode.Text.ToUpper(),
                            "Optional", "<PEmail>", ((string.Empty == this.txtPEmail.Text) ? "Nothing entered" : this.txtPEmail.Text),
                            "Mandatory", "<Phone>", this.txtPhoneNo.Text,
                            "Mandatory", "<Prescription>", this.txtPrescription.Text.Substring(0, 1).ToUpper() + this.txtPrescription.Text.Substring(1).ToLower()
                        };
        #endregion Build up the values of the tags and their replacement values

        #region Replace the email tags with real values
        string emailTemplate = string.Empty;
        try
        {
            emailTemplate = Helper.ReplaceEmailTags(Helper.AppSetting("EmailTemplatePath"), Helper.AppSetting("EmailFileName"), args);
        }
        catch (Exception ex)
        {
        }
        #endregion Replace the email tags with real values

        #region Send the email
        try
        {
            Helper.SendEmail(Helper.AppSetting("PharmacyToMailAddress"), "Patient prescription request", emailTemplate, this.txtPEmail.Text);
        }
        catch (Exception ex)
        {
            this.lblError.Text = "There was a problem sending the order to your email address.  Please try again";
            this.lblError.Visible = true;
        }
        #endregion Send the email

        if (!this.lblError.Visible)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Thank you for filling out the form.  The information will now be emailed to the pharmacy.  If you have any questions, please contact the pharmacy on " + Helper.AppSetting("PharmacyTelephoneNumber") + "')", true);
            this.clearFields();
        }
    }
    
    #region Private methods

    private void clearFields()
    {
        this.txtAddress1.Text = string.Empty;
        this.txtAddress2.Text = string.Empty;
        this.txtCity.Text = string.Empty;
        this.txtCounty.Text = string.Empty;
        this.txtFName.Text = string.Empty;
        this.txtLName.Text = string.Empty;
        this.txtPCode.Text = string.Empty;
        this.txtPEmail.Text = string.Empty;
        this.txtPhoneNo.Text = string.Empty;
        this.txtPrescription.Text = string.Empty;
    }

    /// <summary>
    /// Sets the font labels to black, before 
    /// any need to be set to red.
    /// </summary>
    private void setLabelFontsToBlack()
    {
        this.lblAddress1.ForeColor = System.Drawing.Color.Black;
        this.lblAddress2.ForeColor = System.Drawing.Color.Black;
        this.lblCity.ForeColor = System.Drawing.Color.Black;
        this.lblCounty.ForeColor = System.Drawing.Color.Black;
        this.lblFName.ForeColor = System.Drawing.Color.Black;
        this.lblLName.ForeColor = System.Drawing.Color.Black;
        this.lblPEmail.ForeColor = System.Drawing.Color.Black;
        this.lblPCode.ForeColor = System.Drawing.Color.Black;
        this.lblPhoneNo.ForeColor = System.Drawing.Color.Black;
        this.lblPrescription.ForeColor = System.Drawing.Color.Black;
    }

    /// <summary>
    /// Sets the appropriate error text, based on the 
    /// enum passed in.
    /// </summary>
    /// <param name="error"></param>
    private void setAppropriateErrorText(FieldContainingError error)
    {
        if (error == FieldContainingError.NoError)
        {
            this.lblError.Visible = false;
            this.lblUnsafeValues.Visible = false;
            return;
        }

        string fmt = "The {0} field contains an unsafe value.  Please check and try again, thank you.";

        switch (error)
        {
            case FieldContainingError.Address1:
                this.lblError.Text = string.Format(fmt, "Address1");
                 this.lblAddress1.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.Address2:
                this.lblError.Text = string.Format(fmt, "Address2");
                this.lblAddress2.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.City:
                this.lblError.Text = string.Format(fmt, "City");
                this.lblCity.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.County:
                this.lblError.Text = string.Format(fmt, "County");
                this.lblCounty.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.FirstName:
                this.lblError.Text = string.Format(fmt, "First Name");
                this.lblFName.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.LastName:
                this.lblError.Text = string.Format(fmt, "Last Name");
                this.lblLName.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.PatientEmail:
                this.lblError.Text = string.Format(fmt, "Email");
                this.lblPEmail.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.Postcode:
                this.lblError.Text = string.Format(fmt, "Postcode");
                this.lblPCode.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.Telephone:
                this.lblError.Text = string.Format(fmt, "Telephone");
                this.lblPhoneNo.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.Prescription:
                this.lblError.Text = string.Format(fmt, "Prescription");
                this.lblPrescription.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = true;
                break;
            case FieldContainingError.IncorrectEmailFormat:
                this.lblError.Text = "The email was in the incorrect format";
                this.lblPEmail.ForeColor = System.Drawing.Color.Red;
                this.lblUnsafeValues.Visible = false;
                break;
        }
        this.lblError.Visible = true;
    }

    /// <summary>
    /// Checks all user entry fields to see if they contain safe values.
    /// If not, then an appropriate enum value is returned.
    /// </summary>
    /// <returns></returns>
    private FieldContainingError checkUserEntry()
    {
        if (!Helper.IsUserValueSafe(txtAddress1.Text, this.txtAddress1.MaxLength))
            return FieldContainingError.Address1;

        if (!Helper.IsUserValueSafe(txtAddress2.Text, this.txtAddress2.MaxLength))
            return FieldContainingError.Address2;

        if (!Helper.IsUserValueSafe(txtCity.Text, this.txtCity.MaxLength))
            return FieldContainingError.City;

        if (!Helper.IsUserValueSafe(txtCounty.Text, this.txtCounty.MaxLength))
            return FieldContainingError.County;

        if (!Helper.IsUserValueSafe(txtPCode.Text, this.txtPCode.MaxLength))
            return FieldContainingError.Postcode;

        if (!Helper.IsUserValueSafe(txtPhoneNo.Text, this.txtPhoneNo.MaxLength))
            return FieldContainingError.Telephone;

        if (!Helper.IsUserValueSafe(txtFName.Text, this.txtFName.MaxLength))
            return FieldContainingError.FirstName;

        if (!Helper.IsUserValueSafe(txtLName.Text, this.txtLName.MaxLength))
            return FieldContainingError.LastName;

        if (!Helper.IsUserValueSafe(txtPEmail.Text, this.txtPEmail.MaxLength))
            return FieldContainingError.PatientEmail;

        if (string.Empty != this.txtPEmail.Text && !Helper.ValidEmail(txtPEmail.Text))
            return FieldContainingError.IncorrectEmailFormat;

        if (!Helper.IsUserValueSafe(this.txtPrescription.Text, this.txtPrescription.MaxLength))
            return FieldContainingError.Prescription;

        return FieldContainingError.NoError;
    }
    #endregion Private methods
}