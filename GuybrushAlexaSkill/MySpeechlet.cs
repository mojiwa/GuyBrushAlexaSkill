using System;
using System.Linq;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace GuybrushAlexaSkill
{
   public class MySpeechlet : Speechlet
   {
      public override SpeechletResponse OnIntent(IntentRequest intentRequest, Session session)
      {
         var intent = intentRequest.Intent;
         var intentName = intent?.Name;

         if (intentName.Equals("WhatsYourNameIntent"))
            return BuildSpeechletResponse("WhatsYourNameIntent", "Guybrush Threeepwood", false);

         if (intentName.Equals("FightIntent"))
         {
            var insult = intent.Slots.Values.FirstOrDefault().Value;
            var response = "You need to learn to speak up. Try that insult again, loser.";
            if (insult.Contains("you fight"))
               response = "How appropriate. You fight like a cow.";
            else if (insult.Contains("this is"))
               response = "And I've got a little tip for you, get the, point?";
            else if (insult.Contains("I've spoken with"))
               response = "I'm glad to hear you attended your family reunion.";
            else if (insult.Contains("Soon you'll be"))
               response = "First you better stop waving it about like a feather duster.";
            else if (insult.Contains("people fall"))
               response = "Even before they smell your breath?";
            else if (insult.Contains("I'm not going to take"))
               response = "Your hemorroids are flaring up again eh?";
            else if (insult.Contains("I once owned"))
               response = "He must have taught you everything you know.";
            else if (insult.Contains("nobody's ever drawn"))
               response = "You run, that fast?";
            else if (insult.Contains("have you stopped"))
               response = "Why? Did you want to borrow one?";
            else if (insult.Contains("there are no words"))
               response = "Yes, there are. You just never learned them.";
            else if (insult.Contains("you make me want"))
               response = "You make me think somebody already did.";
            else if (insult.Contains("my handkerchief will"))
               response = "So, you got that job as janitor, after all.";
            else if (insult.Contains("I got this scar"))
               response = "I hope now you've learned to stop picking your nose.";
            else if (insult.Contains("I've heard you are"))
               response = "Too bad no one's ever heard of, you at all.";
            else if (insult.Contains("you're no match"))
               response = "I'd be in real trouble if you ever used them.";
            else if (insult.Contains("you have the manners"))
               response = " wanted to make sure you'd feel comfortable with me.";
            return BuildSpeechletResponse("FightIntent", response, false);
         }

         return BuildSpeechletResponse("Failure", "Failed to recognise", false);
      }

      public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
      {
         return GetWelcomeResponse();
      }

      public override void OnSessionStarted(SessionStartedRequest sessionStartedRequest, Session session)
      {
         Console.WriteLine("This has now started");
      }

      public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
      {
         Console.WriteLine("This has now ended");
      }

      private SpeechletResponse GetWelcomeResponse()
      {
         var speechOutput = "Welcome sword fighter. Throw your first insult, if you have what it takes.";
         return BuildSpeechletResponse("Welcome", speechOutput, false);
      }

      private SpeechletResponse BuildSpeechletResponse(string title, string speechOutput, bool endSession)
      {
         var card = new SimpleCard();
         card.Title = $"{title}";
         card.Content = $"{speechOutput}";

         var speech = new PlainTextOutputSpeech {Text = speechOutput};

         var response = new SpeechletResponse
         {
            ShouldEndSession = endSession,
            OutputSpeech = speech,
            Card = card
         };
         return response;
      }
   }
}