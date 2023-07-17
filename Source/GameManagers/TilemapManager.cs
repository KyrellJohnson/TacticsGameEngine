using System.Numerics;
using TiledCS;
using Raylib_cs;
using TacticsGame.Engine.Utilities;

namespace TacticsGame.Source.GameManagers
{
    public class TilemapManager
    {
        public static TiledMap map = new TiledMap();

        public static Dictionary<int, TiledTileset> tilesets = new Dictionary<int, TiledTileset>();
        public static IEnumerable<TiledLayer>? tileLayers;
        private Texture2D tilesetTexture;
        
        private TiledLayer collisionLayer;
        private TiledLayer spawnPointLayer;

        private System.Drawing.Rectangle? debugRect;
        private Rectangle? debugSelectRect;
        public Camera2D camera;

        public void Initalize(string tilemapSrc, string tilesetTextureSrc, string collisionLayerName, string tilesetSrc = "../../../Assets/Tilesets/")
        {
            map = new TiledMap(tilemapSrc);
            tilesets = (map.GetTiledTilesets(tilesetSrc));
            tileLayers = map.Layers.Where(x => x.type == TiledLayerType.TileLayer);
            tilesetTexture = Raylib.LoadTexture(tilesetTextureSrc);
            collisionLayer = map.Layers.First(layer => layer.name == collisionLayerName);
            spawnPointLayer = map.Layers.First(layer => layer.name == "SpawnPoints" && layer.type == TiledLayerType.ObjectLayer);
        }

        public void Draw()
        {
            DrawTileMap();

            debugRect = null;
            debugSelectRect = null;


            //foreach (var obj in collisionLayer.objects)
            //{
            //    var mousePos = Raylib.GetScreenToWorld2D(Game.inputManager.mousePosition, camera);
            //    var objRect = new System.Drawing.Rectangle((int)obj.x, (int)obj.y, (int)obj.width, (int)obj.height);
            //    if (MathUtils.RectangleContainsPoint(objRect, mousePos))
            //    {
            //        debugRect = objRect;
            //    }
            //}
        }

        public void DrawTileMap()
        {
            if (tileLayers == null) return;
            //TODO: Draw
            foreach (var layer in tileLayers)
            {
                for (var y = 0; y < layer.height; y++)
                {
                    for (var x = 0; x < layer.width; x++)
                    {
                        var index = (y * layer.width) + x; // Assuming the default render order is used which is from right to bottom
                        var gid = layer.data[index]; // The tileset tile index
                        var tileX = (x * map.TileWidth);
                        var tileY = (y * map.TileHeight);

                        // Gid 0 is used to tell there is no tile set
                        if (gid == 0)
                        {
                            continue;
                        }

                        // Helper method to fetch the right TieldMapTileset instance. 
                        // This is a connection object Tiled uses for linking the correct tileset to the gid value using the firstgid property.
                        var mapTileset = map.GetTiledMapTileset(gid);

                        // Retrieve the actual tileset based on the firstgid property of the connection object we retrieved just now
                        var tileset = tilesets[mapTileset.firstgid];

                        // Use the connection object as well as the tileset to figure out the source rectangle.
                        var rect = map.GetSourceRect(mapTileset, tileset, gid);

                        // Render sprite at position tileX, tileY using the rect
                        //Raylib.DrawRectangle(rect.x, rect.y, rect.width, rect.height, new Color());
                        //Console.WriteLine(rect);


                        var source = new Rectangle(rect.x, rect.y, rect.width, rect.height);
                        var dest = new Rectangle(tileX, tileY, map.TileWidth, map.TileHeight);

                        if (map.IsTileFlippedHorizontal(layer, x, y))
                        {
                            source.width = -(source.width);
                        }

                        

                        Raylib.DrawTexturePro(tilesetTexture, source, dest, Vector2.Zero, 0f, Color.WHITE);

                        var mousePos = Raylib.GetScreenToWorld2D(Game.inputManager.mousePosition, camera);

                        if (MathUtils.RectangleContainsPoint(dest, mousePos))
                        {
                            debugSelectRect = dest;
                        }

                        if (MathUtils.RectangleContainsPoint(dest, mousePos) && layer == collisionLayer)
                        {
                            debugRect = new System.Drawing.Rectangle((int)dest.x, (int)dest.y, (int)dest.width, (int)dest.height); ;
                        }

                    }
                }

            }

            // If mouse is over a collider, display its bounds
            if (debugRect != null)
            {
                Raylib.DrawRectangle(debugRect.Value.X, debugRect.Value.Y, debugRect.Value.Width, debugRect.Value.Height, Color.RED);
            }

            if(debugSelectRect != null && debugRect == null)
            {
                Raylib.DrawRectangle((int)debugSelectRect.Value.x, (int)debugSelectRect.Value.y, (int)debugSelectRect.Value.width, (int)debugSelectRect.Value.height, Color.GREEN);
            }
        }
    }
}

