﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Survey.Application.Repositories.Interfaces;
using Survey.Domain.SurveyAggregate;

namespace Survey.Application.Services
{
    public class SurveyService
    {
        private readonly IRepository<Answers> _repository;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;

        public SurveyService(IRepository<Answers> repository, IConfiguration configuration, ICacheService cacheService)
        {
            _repository = repository;
            _configuration = configuration;
            _cacheService = cacheService;
        }

        public async Task SendDailySurveyReport()
        {
            var answers = await _repository.GetAll(x => x.CreatedDate.Day == DateTime.UtcNow.Day);

            int answerCount = answers.Count();
            var getEmail = await _cacheService.GetAsync<string>("email");
            var message = new MimeMessage();
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            message.From.Add(new MailboxAddress(smtpSettings["SenderName"], smtpSettings["SenderEmail"]));
            message.To.Add(new MailboxAddress("", getEmail));
            message.Subject = "Daily Survey Report";
            message.Body = new TextPart("plain")
            {
                Text = $"Today's survey answer count is: {answerCount}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpSettings["Server"], int.Parse(smtpSettings["Port"]), false);
                await client.AuthenticateAsync(smtpSettings["Username"], smtpSettings["Password"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
