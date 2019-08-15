using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace HMS.utility
{
    public static class Emailer
    {
        public static bool SendMail(string mailTo, string mailFrom, string mailSubject, string mailBody)
        {
            bool isMailSend = false;
            //create the mail message
            MailMessage mail = new MailMessage();
            //set the FROM address
            mail.From = new MailAddress(mailFrom);
            //set the RECIPIENTS
            mail.To.Add(mailTo);
            //enter a SUBJECT
            mail.Subject = mailSubject;
            //Enter the message BODY
            mail.Body = mailBody;
            //set the mail server (default should be smtp.1and1.com)
            SmtpClient smtp = new SmtpClient("smtp.1and1.com");
            //Enter your full e-mail address and password
            smtp.Credentials = new NetworkCredential(mailFrom, HMSContent.noreplyPassword);
            //send the message
            smtp.Send(mail);//for test
            isMailSend = true;

            return isMailSend;
        }

       
        
    }
    public static class HMSContent
    {
        public static string SubscriberMailBody = "Thank you for registering your interest with the Comparehajjpackages.com. Your details have been added to our database and we will be in touch shortly with the latest updates on the website.";
        public static string enquiryMailAddress = "enquiry@comparehajjpackages.com";
        public static string enquiryMailPassword = "Secret?";
        public static string SubscriberMailSubject = "Thank you for registering interest.";
        public static string noreply = "noreply@comparehajjpackages.com";
        public static string noreplyPassword = "Abc1234";

    }

    public static class utility
    {
        public static int getDuration(int DurationId)
        {
            int Duration = 0;
            if (DurationId == 1)
            {
                Duration = 6;
            }
            else if (DurationId == 2)
            {
                Duration = 10;
            }
            else if (DurationId == 3)
            {
                Duration = 15;
            }
            else if (DurationId == 4)
            {
                Duration = 21;
            }
            else if (DurationId == 5)
            {
                Duration = 30;
            }
            else if (DurationId == 6)
            {
                Duration = 31;
            }
            return Duration;
        }
        public static string AdverticeTemplate =
            "<div class='item  [cposition]' ><a href='#'><img src='[imglocation]' alt='banner' /></a></div>";

        public static string CrusarTemplate = "<div id='div[position]' class='carousel slide '><div class='carousel-inner '>[itemTemplate]</div></div>";
    }
}