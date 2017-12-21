using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;

namespace Email
{
    /// <summary>  
    /// 发送邮件[you jian]的类  
    /// </summary>
    public class Mail
    {
        private MailMessage mailMessage;
        private SmtpClient smtpClient;
        private string password;//发件人密码[mi ma]  
        /**/
        /// <summary>  
        /// 处审核后类的实例  
        /// </summary>  
        /// <param name="To">收件人地址[di zhi]</param>  
        /// <param name="From">发件人地址[di zhi]</param>  
        /// <param name="Body">邮件[you jian]正文[zheng wen]</param>  
        /// <param name="Title">邮件[you jian]的主题</param>  
        /// <param name="Password">发件人密码[mi ma]</param>
        public Mail(string To, string From, string Body, string Title, string Password)
        {
            mailMessage = new MailMessage();
            mailMessage.To.Add(To);
            mailMessage.From = new System.Net.Mail.MailAddress(From);
            mailMessage.Subject = Title;
            mailMessage.Body = Body;
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Priority = System.Net.Mail.MailPriority.Normal;
            this.password = Password;
            Console.WriteLine("send mail sucssesful");
        }
        /**/
        /// <summary>  
        /// 添加附件  
        /// </summary>
        public void Attachments(string Path)
        {
            string[] path = Path.Split(',');
            Attachment data;
            ContentDisposition disposition;
            for (int i = 0; i < path.Length; i++)
            {
                data = new Attachment(path[i], MediaTypeNames.Application.Octet);//实例化[shi li hua]附件  
                disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(path[i]);//获取附件的创建日期[chuang jian ri qi]  
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(path[i]);//获取附件的修改[xiu gai]日期  
                disposition.ReadDate = System.IO.File.GetLastAccessTime(path[i]);//获取附件的读取[du qu]日期  
                mailMessage.Attachments.Add(data);//添加到附件中  
            }
        }
        /// <summary>  
        /// 发送邮件[you jian]  
        /// </summary>
        public void Send()
        {
            if (mailMessage != null)
            {
                smtpClient = new SmtpClient();
                smtpClient.Credentials = new System.Net.NetworkCredential(mailMessage.From.Address, password);//设置[she zhi]发件人身份[shen fen]的票据  
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP"].ToString();
                smtpClient.Timeout = 100000;
                smtpClient.Send(mailMessage);
            }
        }

        public static void SendMail(string to, string body, string title)
        {
            string sendmailaddress;
            string password;
            sendmailaddress = System.Configuration.ConfigurationManager.AppSettings["EmailAccount"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"].ToString();
            Mail mail = new Mail(to, sendmailaddress, body, title, password);
            mail.Send();
        }
        /// <summary>
        /// 带附件发送
        /// </summary>
        /// <param name="to"></param>
        /// <param name="body"></param>
        /// <param name="title"></param>
        /// <param name="path"></param>
        public static void SendMail(string to, string body, string title,string path)
        {
            string sendmailaddress;
            string password;
            sendmailaddress = System.Configuration.ConfigurationManager.AppSettings["EmailAccount"].ToString();
            password = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"].ToString();
            Mail mail = new Mail(to, sendmailaddress, body, title, password);
            mail.Attachments(path);
            mail.Send();
        }
    }
}