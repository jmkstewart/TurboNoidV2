using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboNoid.CommunicationObjects {
    public class GameInfo : IGameInfo {
        public int Lives { get; set; }
        public int Level { get; set; }
        public bool Dead { get; set; }
        public bool GameOver { get; set; }
        public bool NextLevel { get; set; }
    }
}
