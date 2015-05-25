using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace RssToEmail
{
    class Program
    {        
        public class ChannelClass
        {
            public string title;

            public ChannelClass()
            {
                title = "";
            }
        }

        public class Items
        {
            public string title;
            public string link;
            public string description;
            public string pubDate;

            public Items()
            {
                title = "";
                link = "";
                description = "";
                pubDate = "";
            }
        }

        static void Main(string[] args)
        {
            SendRSSToEmail();
        }
        static void SendRSSToEmail()
        {
            ChannelClass channel = new ChannelClass();
            try
            {
                Console.WriteLine("Введите адрес RSS-потока");
                string RSSLink = Console.ReadLine();

            
                XmlDocument doc = new XmlDocument();
                doc.Load(RSSLink);
            

            XmlNodeList nodeList;
            XmlNode root = doc.DocumentElement;
            Items[] articles = new Items[root.SelectNodes("channel/item").Count];
            nodeList = root.ChildNodes;
            int count = 0;
            
            foreach (XmlNode c in nodeList)
                {
                    foreach (XmlNode c_item in c)
                    {
                        if (c_item.Name == "title")
                            channel.title = c_item.InnerText;

                        if (c_item.Name == "item")
                        {
                            XmlNodeList itemsList = c_item.ChildNodes;
                            articles[count] = new Items();

                            foreach (XmlNode item in itemsList)
                            {
                                if (item.Name == "title")                                
                                    articles[count].title = item.InnerText;
                                
                                if (item.Name == "link")
                                    articles[count].link = item.InnerText;
                                
                                if (item.Name == "description")
                                    articles[count].description = item.InnerText;
                                
                                if (item.Name == "pubDate")
                                    articles[count].pubDate = item.InnerText;
                            }
                            count++;
                        }
                    }
                }
            
            // Отправка сообщения
            MailMessage mail = new MailMessage();
            Console.WriteLine("Введите адрес отправителя");
            mail.From = new MailAddress(Console.ReadLine());
            Console.WriteLine("Введите адрес получателя");
            mail.To.Add(new MailAddress(Console.ReadLine()));
            
            mail.Subject = channel.title;
            mail.Body = articles[1].title + "\n\n" + articles[1].description + "\n\n" + articles[1].link + "\n\n" + articles[1].pubDate;
                
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Port = 587;
            client.EnableSsl = true;
            Console.WriteLine("Введите логин и пароль");
            client.Credentials = new NetworkCredential(Console.ReadLine(), Console.ReadLine());
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
            mail.Dispose();
           }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                SendRSSToEmail();
            } 
           
            Console.ReadKey();

        }
    }
}
