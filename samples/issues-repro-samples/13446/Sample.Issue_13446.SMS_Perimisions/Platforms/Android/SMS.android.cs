using System;
using System.Collections.ObjectModel;
using Sample.Issue_13446.SMS_Perimisions;

namespace Sample.Issue_13446.SMS_Perimisions.Platforms.Android
{
	public class SMS
	{
		public SMS()
		{
            Log = new ObservableCollection<ErrorLogItem>();

            return;
		}

        public void Send(String phoneNumber, String message)
        {
            // Get the SMS manager
            global::Android.Telephony.SmsManager smsManager = global::Android.Telephony.SmsManager.Default;
            // Split text message content (SMS length limit)
            IList<string> divideContents = smsManager.DivideMessage(message);
            foreach (string text in divideContents)
            {
                try
                {
                    smsManager.SendTextMessage(phoneNumber, null, text, null, null);
                }
                catch(Exception exc)
                {
                    string msg = exc.Message;

                    ErrorLogItem eli = new ErrorLogItem()
                    {
                        DateTimeStamp = DateTime.Now,
                        Message = msg,
                    };

                    this.Log.Add(eli);

                    global::Android.Util.Log.WriteLine
                                                (
                                                    global::Android.Util.LogPriority.Info,
                                                    "SMS log size",
                                                    Log.Count.ToString()
                                                );
                    global::Android.Util.Log.WriteLine
                                                (
                                                    global::Android.Util.LogPriority.Error,
                                                    "SMS",
                                                    msg
                                                );

                    //throw;
                }
            }

            return;
        }

        public ObservableCollection<ErrorLogItem> Log
        {
            get;
            set;
        }
    }

}

/*
Android.Telephony.SmsManager

Warning CA1422: This call site is reachable on: 'Android' 21.0 and later. 'SmsManager.Default' is obsoleted on: 'Android' 31.0 and later. (CA1422) 

Android.Telephony.Gsm.SmsManager

Warning CS0618: 'SmsManager' is obsolete: 'This class is obsoleted in this android platform' (CS0618) 
Warning CS0618: 'SmsManager' is obsolete: 'This class is obsoleted in this android platform' (CS0618) 
Warning CS0618: 'SmsManager.Default' is obsolete: 'deprecated' (CS0618) 
Warning CS0618: 'SmsManager.DivideMessage(string?)' is obsolete: 'deprecated' (CS0618) 
Warning CS0618: 'SmsManager.SendTextMessage(string?, string?, string?, PendingIntent?, PendingIntent?)' is obsolete: 'deprecated' (CS0618) 
*/

