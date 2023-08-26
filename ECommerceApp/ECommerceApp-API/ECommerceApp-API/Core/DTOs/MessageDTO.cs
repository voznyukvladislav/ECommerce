namespace ECommerceApp_API.Core.DTOs
{
    public class MessageDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    
        public static MessageDTO CreateSuccessful(string title, string text)
        {
            MessageDTO message = new MessageDTO();
            message.Title = title;
            message.Status = MessageDTOStatusNames.Successful;
            message.Text = text;

            return message;
        }

        public static MessageDTO CreateFailed(string title, string text)
        {
            MessageDTO message = new MessageDTO();
            message.Title = title;
            message.Status = MessageDTOStatusNames.Failed;
            message.Text = text;

            return message;
        }
    }
}
