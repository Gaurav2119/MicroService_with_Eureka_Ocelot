namespace CartAPI.MessageConsume
{
    public class KafkaConsumerConfig
    {
        public string GroupId { get; set; }
        public string BootstrapServers { get; set; }
        public string ClientId { get; set; }
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
        public string TopicSubscribed { get; set; }
    }
}
