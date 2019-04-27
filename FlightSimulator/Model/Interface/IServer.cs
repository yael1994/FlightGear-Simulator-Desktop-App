namespace FlightSimulator.Model
{
    internal interface IServer
    {
        void Start();
        string [] Read();
        void Disconnect();
    }
}