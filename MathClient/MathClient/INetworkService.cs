namespace MathClient
{
    // Common interface for TCP and UDP client classes
    interface INetworkService
    {
        void SendMessage();
    }
}