using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.Xml;

namespace TP05_Douglas
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ValidateXml(string xmlFilePath, string xsdFilePath)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.DtdProcessing = DtdProcessing.Parse;

                if (!string.IsNullOrEmpty(xsdFilePath))
                {
                    settings.Schemas.Add(null, xsdFilePath); 
                }

                settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    while (reader.Read()) { }
                }

                ResultLabel.Text = "XML válido!";
            }
            catch (XmlException xmlEx)
            {
                ResultLabel.Text = "Erro XML: " + xmlEx.Message;
            }
            catch (Exception ex)
            {
                ResultLabel.Text = "Erro: " + ex.Message;
            }
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                ResultLabel.Text = "Aviso XML: " + e.Message;
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                ResultLabel.Text = "Erro XML: " + e.Message;
            }
        }

        protected void ValidateButton_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string xmlFilePath = Server.MapPath("~/UploadedFiles/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(xmlFilePath);

                    string xsdFilePath = null;
                    if (XSDUpload.HasFile)
                    {
                        xsdFilePath = Server.MapPath("~/UploadedFiles/" + XSDUpload.FileName);
                        XSDUpload.SaveAs(xsdFilePath);
                    }

                    ValidateXml(xmlFilePath, xsdFilePath);
                }
                catch (Exception ex)
                {
                    ResultLabel.Text = "Erro: " + ex.Message;
                }
            }
            else
            {
                ResultLabel.Text = "Por favor, selecione um arquivo XML.";
            }
        }
    }
}