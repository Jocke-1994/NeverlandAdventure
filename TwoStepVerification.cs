using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NeverlandAdventure
{
    public class TwoStepVerification
    {
        private readonly string _accountSid; // Twilio Account SID
        private readonly string _authToken; // Twilio Auth Token
        private readonly string _fromNumber; // Twilio phone number

        //Konstruktor: initierar Twilio-klienten med autentiseringsuppgifter från miljövariabler.
        public TwoStepVerification()
        {
            _accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            _authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            _fromNumber = Environment.GetEnvironmentVariable("TWILIO_FROM_NUMBER");

            if (string.IsNullOrEmpty(_accountSid) || string.IsNullOrEmpty(_authToken))
                throw new InvalidOperationException("Twilio credentials are not set in environment variables.");

            TwilioClient.Init(_accountSid, _authToken);

        }
        public async Task<string> SendSmsAsync(string toNumber, string message)
        {
            try
            {
                var messageResource = await MessageResource.CreateAsync(
                    to: new PhoneNumber(toNumber),
                    from: new PhoneNumber(_fromNumber ?? "+16202993271"),
                    body: message
                );

                Console.WriteLine($"SMS skickat till {toNumber}: {message}");
                return messageResource.Sid;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skickande av SMS: {ex.Message}");
                return null;
            }


        }

    }
}
