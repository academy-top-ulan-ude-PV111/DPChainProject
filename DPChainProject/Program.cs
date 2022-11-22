namespace DPChainProject
{
    class MessageSender
    {
        public bool EmailSender { set; get; }
        public bool SmsSender { set; get; }
        public bool TelegramSender { set; get; }
        public bool WathsupSender { set; get; }

        public MessageSender(bool emailSender, bool smsSender, bool telegramSender, bool wathsupSender)
        {
            EmailSender = emailSender;
            SmsSender = smsSender;
            TelegramSender = telegramSender;
            WathsupSender = wathsupSender;
        }
    }

    abstract class SenderHandler
    {
        public SenderHandler Handler { set; get; }

        public SenderHandler(SenderHandler handler = null)
        {
            Handler = handler;
        }

        public abstract void SendHandle(MessageSender sender);
    }

    class EmailSenderHandler : SenderHandler
    {
        public EmailSenderHandler(SenderHandler sender) : base(sender) { }
        public override void SendHandle(MessageSender sender)
        {
            if(sender.EmailSender)
                Console.WriteLine("Message send Email");
            else
            {
                if(Handler != null)
                {
                    Handler.SendHandle(sender);
                }
            }
        }
    }

    class SmsSenderHandler : SenderHandler
    {
        public SmsSenderHandler(SenderHandler sender) : base(sender) { }
        public override void SendHandle(MessageSender sender)
        {
            if (sender.SmsSender)
                Console.WriteLine("Message send Sms");
            else
            {
                if (Handler != null)
                {
                    Handler.SendHandle(sender);
                }
            }
        }
    }

    class TelegramSenderHandler : SenderHandler
    {
        public TelegramSenderHandler(SenderHandler sender) : base(sender) { }
        public override void SendHandle(MessageSender sender)
        {
            if (sender.TelegramSender)
                Console.WriteLine("Message send Telegram");
            else
            {
                if (Handler != null)
                {
                    Handler.SendHandle(sender);
                }
            }
        }
    }

    class WathsupSenderHandler : SenderHandler
    {
        public WathsupSenderHandler(SenderHandler sender = null) : base(sender) { }
        public override void SendHandle(MessageSender sender)
        {
            if (sender.WathsupSender)
                Console.WriteLine("Message send Telegram");
            else
            {
                if (Handler != null)
                {
                    Handler.SendHandle(sender);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageSender sender = new MessageSender(false, false, true, true);

            //SenderHandler email = new EmailSenderHandler();
            //SenderHandler sms = new SmsSenderHandler();
            //SenderHandler telegram = new TelegramSenderHandler();
            //SenderHandler wathup = new WathsupSenderHandler();

            //email.Handler = sms;
            //sms.Handler = telegram;
            //telegram.Handler = wathup;

            SenderHandler headSender = 
                new EmailSenderHandler(
                    new SmsSenderHandler(
                        new TelegramSenderHandler(
                            new WathsupSenderHandler()
                        )
                    )
                );

            headSender.SendHandle(sender);
        }
    }
}