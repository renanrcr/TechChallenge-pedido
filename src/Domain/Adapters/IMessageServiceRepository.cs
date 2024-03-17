namespace Domain.Adapters
{
    public interface IMessageServiceRepository
    {
        bool Enqueue(object message);
    }
}
