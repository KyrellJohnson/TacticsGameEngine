using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using TacticsGame.Engine.Utilities;
using TiledCS;

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

        public static List<Vector2> spawnPoints = new List<Vector2>();
        public static List<Vector2> colliderPositions = new List<Vector2>();

        private System.Drawing.Rectangle? debugRect;
        private Rectangle? debugSelectRect;
        public Camera2D camera;
        List<List<short>> lists = new List<List<short>>(); /////https://www.techiedelight.com/convert-a-list-of-lists-to-a-2d-array-in-csharp/

        public short[,] grid;

        public void Initalize(string tilemapSrc, string tilesetTextureSrc, string collisionLayerName, string tilesetSrc = "../../../Assets/Tilesets/")
        {
            map = new TiledMap(tilemapSrc);
            tilesets = (map.GetTiledTilesets(tilesetSrc));
            tileLayers = map.Layers.Where(x => x.type == TiledLayerType.TileLayer);
            tilesetTexture = Raylib.LoadTexture(tilesetTextureSrc);
            collisionLayer = map.Layers.First(layer => layer.name == collisionLayerName);
            spawnPointLayer = map.Layers.First(layer => layer.name == "SpawnPoints" && layer.type == TiledLayerType.ObjectLayer);

            GetColliderPositions(collisionLayer);
            foreach (var collider in colliderPositions)
                Console.WriteLine(collider);
            GetSpawnPoints();

            List<short> rep = new List<short>();


            for (int y = 0; y < collisionLayer.height; y++)
            {
                rep.Clear();

                for (int x = 0; x < collisionLayer.width; x++)
                {
                    var index = (y * collisionLayer.width) + x; // Assuming the default render order is used which is from right to bottom
                    var gid = collisionLayer.data[index]; // The tileset tile index
                                                          // Gid 0 is used to tell there is no tile set
                    if (gid == 0)
                    {
                        rep.Add((short)321);
                        Console.Write("!"+x);
                        Console.WriteLine("\t " + y);
                        continue;
                    }
                    else
                    {
                        Console.Write(x);
                        Console.WriteLine("\t " + y);
                        rep.Add((short)123);
                    }

                    
                }
                lists.Add(rep);
            }


            Console.WriteLine(lists.ElementAt(10).ElementAt(10));

        }

        public void Draw()
        {
            DrawTileMap();

            debugRect = null;
            debugSelectRect = null;
        }

        public void GetSpawnPoints()
        {
            foreach (var obj in spawnPointLayer.objects)
            {
                spawnPoints.Add(new Vector2(obj.x, obj.y));
            }
        }

        public void GetColliderPositions(TiledLayer collisionLayer)
        {



            foreach (var layer in tileLayers)
            {
                if (layer != collisionLayer) continue;

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
                        var dest = new Rectangle(tileX, tileY, map.TileWidth, map.TileHeight);


                        colliderPositions.Add(new Vector2(dest.x, dest.y));



                    }
                }
            }
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

            if (debugSelectRect != null && debugRect == null)
            {
                Raylib.DrawRectangle((int)debugSelectRect.Value.x, (int)debugSelectRect.Value.y, (int)debugSelectRect.Value.width, (int)debugSelectRect.Value.height, Color.GREEN);
            }
        }
    }
}

