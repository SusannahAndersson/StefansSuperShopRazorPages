using Microsoft.EntityFrameworkCore;
using StefansSuperShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StefansSuperShop.Services
{
    public interface INewsletterService
    {
        public Newsletter GetNewsletter(int id);
        public List<Newsletter> GetAllNewsletters();
        public bool AddNewsletter(Newsletter newsletter);
        public bool IsEmailSubscriber(string email);//TODO: IsEmailSubscribed?
        public List<string> GetSubscriberEmails();
        public Newsletter CreateNewsletter(string title, string body);
        public void AddSubscriber(string mail);

    }
    public class NewsletterService : INewsletterService
    {
        private readonly ApplicationDbContext _context;

        public NewsletterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Newsletter? GetNewsletter(int id)
        {
            //TODO: add error handling if id is not found
            return _context.Newsletters.Find(id);
        }

        public List<Newsletter> GetAllNewsletters()
        {
            return _context.Newsletters.ToList();
        }

        public bool AddNewsletter(Newsletter newsletter)
        {
            _context.Newsletters.Add(newsletter);
            return _context.SaveChanges() > 0;//if updates were succesful, will be more than one, will return true
        }

        public Newsletter CreateNewsletter(string title, string body)
        {
            Newsletter newsletter = new Newsletter()
            {
                Title = title,
                Body = body,
                Subscribers = GetSubscribers()
            };

            return newsletter;
        }

        //TODO: jag kunde inte casta _context.Subscribers till ICollection<NewsletterSubscriber> så gjorde denna metod
        //finns det ett bättre sätt?
        private ICollection<NewsletterSubscriber> GetSubscribers()
        {
            List<NewsletterSubscriber> subscribers = new();

            foreach(var s in _context.Subscribers)
            {
                subscribers.Add(s);
            }

            return subscribers;
        }

        public bool IsEmailSubscriber(string email)
        {
            return _context.Subscribers.Any(s => s.Mail == email);
        }

        public List<string> GetSubscriberEmails()
        {
            List<string> emails = new List<string>();

            foreach (var subscriber in _context.Subscribers)
            {
                emails.Add(subscriber.Mail);
            }

            return emails;
        }

        public void AddSubscriber(string mail)
        {
            _context.Subscribers.Add(new NewsletterSubscriber { Mail = mail });
            _context.SaveChanges();
        }

    }
}

