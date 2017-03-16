using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.Components.Interfaces;
using RavenWebPayroll.Common.Components.DTO;
using RavenWebPayroll.Common.Components.Controllers;
using RavenWebPayroll.Common.Components.Models;

namespace RavenWebPayroll.UI.main.views.configuration
{
    public partial class CompanyInfoForm : System.Web.UI.UserControl, ISinglePageDataForm, ICompanyInformation  
    {
        CompanyInformationModel _model;
        CompanyInformationController _controller;

        #region ISinglePageDataForm Members

        public void LoadData()
        {
            _model = new CompanyInformationModel();
            _controller = new CompanyInformationController(this, _model);
        }

        /// <summary>
        /// Interchangeable with VISIBLE property
        /// </summary>
        public bool Display
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }

        #endregion

        #region ICompanyInformation Members

        public void LoadData(CompanyInformationDTO companyInformationDTO)
        {
            try
            {
                this.CompanyNameTextBox.Text = companyInformationDTO.CompanyName;
                this.AddressTextBox.Text = companyInformationDTO.Address;
                this.PhoneNumberTextBox.Text = companyInformationDTO.PhoneNumber;
                this.ZipCodeTextBox.Text = companyInformationDTO.ZipCode;
                this.TINTextBox.Text = companyInformationDTO.TIN;

            }
            catch (Exception ex)
            {
                NotifyExceptionOccurence(new ExceptionNotification(ex.Message));
            }
        }

        #endregion

        #region IResponder Members

        public event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        #endregion



        #region ISinglePageDataForm Members


        public bool Save()
        {
            CompanyInformationDTO companyInfoDTO = new CompanyInformationDTO 
            {
                CompanyName = CompanyNameTextBox.Text,
                Address = AddressTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                TIN = TINTextBox.Text,
                ZipCode = ZipCodeTextBox.Text
            };
            
            SubmitChanges(companyInfoDTO);
            return true;
        }

        #endregion

        #region ICompanyInformation Members
        
        public void SubmitChanges(CompanyInformationDTO companyInformationDTO)
        {
            if (_controller == null)
            {
                if (_model == null)
                    _model = new CompanyInformationModel();

                _controller = new CompanyInformationController(this, _model);
                _model.NotifySuccessfulOperation += new NotifySuccessfulOperationEventHandler(NotifySuccess);
            }

            _controller.CompanyInformation = companyInformationDTO;

            
        }

        #endregion

        public void NotifySuccess(string message)
        {
            NotifySuccessfulOperation(message);

            this.LoadData();
        }

        #region IResponder Members


        public event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;

        #endregion
    }
}