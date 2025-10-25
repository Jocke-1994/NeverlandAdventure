using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NeverlandAdventure.StartMenu
{
    public class TwoStepVerificationSMS
    {
        private readonly string _accountSid; // Twilio Account SID
        private readonly string _authToken; // Twilio Auth Token
        private readonly string _fromNumber; // Twilio phone number

        //Konstruktor: initierar Twilio-klienten med autentiseringsuppgifter från miljövariabler.
        public TwoStepVerificationSMS()
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
            if (string.IsNullOrEmpty(_accountSid) || string.IsNullOrEmpty(_authToken))

                return "Twilio not configured.";
            
            try
            {
                var msg = await Twilio.Rest.Api.V2010.Account.MessageResource.CreateAsync(
                    to: new Twilio.Types.PhoneNumber(toNumber),
                    from: new Twilio.Types.PhoneNumber(_fromNumber),
                    body: message
                );

                return $"SMS sent";

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skickande av SMS: {ex.Message}");
                return null;
            }


        }

    }
}
