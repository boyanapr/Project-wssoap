using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

namespace Demo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(txtmailadd.Text, "Sender's Name");
            msg.To.Add(new MailAddress(txtTo.Text));
            msg.Subject = txtsub.Text;
            msg.Body = txtmsg.Text;
            msg.IsBodyHtml = true;

            if (FileUpload1.HasFile)
            {
                msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential(txtmailadd.Text, txtmailpass.Text);

            lblresult.Visible = true;
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
                lblresult.Text = "E-mail Send Successfully...";
            }
            catch(Exception ex)
            {
                lblresult.Text = ex.Message;
            }
        }
        
    }
}