namespace ProductAPI.MessageProduce
{
    public interface IProducer
    {
        Task ProduceMessage(Guid key, object message);
    }
}
