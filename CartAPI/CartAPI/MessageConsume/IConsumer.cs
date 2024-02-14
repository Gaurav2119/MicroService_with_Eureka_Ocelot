using CartAPI.Dtos;

namespace CartAPI.MessageConsume
{
    public interface IConsumer
    {
        void ConsumeMessage(CancellationToken cts);
        void RunInBackground();
    }
}
