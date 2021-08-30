using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace ASPCourse1.Utility
{
    public class EmailSender : IEmailSender
    {

    private readonly IConfiguration _configuration;
    public MailJetSettings _mailJetSettings { get; set; }

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            _mailJetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();
            MailjetClient client =
                new MailjetClient(_mailJetSettings.ApiKey, _mailJetSettings.SecretKey);
     
            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource
            }
                .Property(Send.Messages, new JArray {
                    new JObject {
                        {
                            "From",
                            new JObject {
                                {"Email", "sidbird83@gmail.com"},
                                {"Name", "Michel"}
                            }
                        }, {
                            "To",
                            new JArray {
                                new JObject {
                                    {
                                        "Email",
                                        email
                                    }, {
                                        "Name",
                                        "Dotnet"
                                    }
                                }
                            }
                        }, {
                            "Subject",
                            subject
                        },  {
                            "HTMLPart",
                            body
                        }
                    }
                });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
