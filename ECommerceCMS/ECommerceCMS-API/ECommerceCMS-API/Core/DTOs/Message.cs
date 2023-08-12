namespace ECommerceCMS_API.Core.DTOs
{
    public class Message
    {
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        
        public Message(string title, string status, string text)
        {
            Title = title;
            Status = status;
            Text = text;
        }

        public Message() { }

        public static Message CreateSuccessful(string title, string text)
        {
            Message message = new Message();
            message.Title = title;
            message.Text = text;
            message.Status = MessageStatusNames.Successful;

            if (message.Text[message.Text.Length - 1] != '.')
            {
                message.Text += ".";
            }

            return message;
        }

        public static Message CreateFailed(string title, string text)
        {
            Message message = new Message();
            message.Title = title;
            message.Text = text;
            message.Status = MessageStatusNames.Failed;

            if (message.Text[message.Text.Length - 1] != '.')
            {
                message.Text += ".";
            }

            return message;
        }
    }
}
