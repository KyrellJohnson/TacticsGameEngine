using System;
using TiledCS;
using Raylib_cs;

namespace TacticsGame.Source.GameManagers
{
    public class TilemapManager
    {
        public static Dictionary<string, TiledMap> maps = new Dictionary<string, TiledMap>();
        public static Dictionary<int, TiledTileset> tilesets = new Dictionary<int, TiledTileset>();
        public static IEnumerable<TiledLayer>? tileLayers;

        public TilemapManager()
        {
            LoadInTileMaps();

            //TODO: Draw
            foreach(var layer in tileLayers)
            {
                for (var y = 0; y < layer.height; y++)
                {
                    for (var x = 0; x < layer.width; x++)
                    {
                        var index = (y * layer.width) + x; // Assuming the default render order is used which is from right to bottom
                        var gid = layer.data[index]; // The tileset tile index
                        var tileX = (x * maps["tilemap"].TileWidth);
                        var tileY = (y * maps["tilemap"].TileHeight);

                        // Gid 0 is used to tell there is no tile set
                        if (gid == 0)
                        {
                            continue;
                        }

                        // Helper method to fetch the right TieldMapTileset instance. 
                        // This is a connection object Tiled uses for linking the correct tileset to the gid value using the firstgid property.
                        var mapTileset = maps["tilemap"].GetTiledMapTileset(gid);

                        // Retrieve the actual tileset based on the firstgid property of the connection object we retrieved just now
                        var tileset = tilesets[mapTileset.firstgid];

                        // Use the connection object as well as the tileset to figure out the source rectangle.
                        var rect = maps["tilemap"].GetSourceRect(mapTileset, tileset, gid);

                        // Render sprite at position tileX, tileY using the rect
                        Raylib.DrawRectangle(rect.x, rect.y, rect.width, rect.height, Color.GOLD);
                    }
                }
            }
            
        }

        public void LoadInTileMaps()
        {
            maps.Add("tilemap", new TiledMap(@"../../Assets/Tilemaps/Level_Main.tmx"));
            tilesets = (maps["tilemap"].GetTiledTilesets("../../Assets/Tilesets/"));
            tileLayers = maps["tilemap"].Layers.Where(x => x.type == TiledLayerType.TileLayer);

        }
    }
}

