namespace MathServer
{
    // Common interface for TCP and UDP server classes
    interface INetworkService
    {
        void SendResult(MathService ms);
    }
}