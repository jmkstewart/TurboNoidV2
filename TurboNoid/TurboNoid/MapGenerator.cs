using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TurboNoid.DrawableObjects.Sprites;
using System.IO;
using Microsoft.Xna.Framework;

namespace TurboNoid {
    class MapGenerator {
        private string _mapFileLocation;

        public MapGenerator(string mapFileLocation) {
            _mapFileLocation = mapFileLocation;
        }

        public List<Block> GetBlockList(Game game, string mapName) {
            var blockList = new List<Block>();

            int x = 10;
            int y = 10;

            using(StreamReader sr = File.OpenText(Path.Combine(_mapFileLocation, mapName))) {
                string mapLine;
                while((mapLine = sr.ReadLine()) != null) {
                    foreach(var colour in mapLine) {
                        if(colour == 'r') {
                            blockList.Add(new Block(game, new Vector2(x, y), BlockColour.Red));
                        } else if(colour == 'b') {
                            blockList.Add(new Block(game, new Vector2(x, y), BlockColour.Blue));
                        } else if(colour == 'w') {
                            blockList.Add(new Block(game, new Vector2(x, y), BlockColour.White));
                        }
                        
                        x += 87;
                    }

                    x = 10;
                    y += 38;
                }
            }

            return blockList;
        }
    }
}
