namespace ECommerceApp_API.Core.DTOs
{
    public class ContentMessageDTO<T>
    {
        public MessageDTO Message { get; set; }
        public T Content { get; set; }

        public ContentMessageDTO(MessageDTO messageDTO, T content)
        {
            this.Message = messageDTO;
            this.Content = content;
        }
    }
}
