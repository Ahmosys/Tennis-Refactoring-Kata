namespace Tennis.Interfaces
{
    internal interface IPlayer
    {
        string Name { get; }
        int Score { get; }
        void WonPoint();
    }
}
