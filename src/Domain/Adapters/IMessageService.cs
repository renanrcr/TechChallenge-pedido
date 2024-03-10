namespace Domain.Adapters
{
    public interface IMessageService
    {
        bool Enqueue(object message);
    }
}
