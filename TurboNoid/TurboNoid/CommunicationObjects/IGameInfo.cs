namespace TurboNoid.CommunicationObjects {
    public interface IGameInfo {
        int Lives { get; set; }
        int Level { get; set; }
        bool Dead { get; set; }
        bool GameOver { get; set; }
        bool NextLevel { get; set; }
    }
}
