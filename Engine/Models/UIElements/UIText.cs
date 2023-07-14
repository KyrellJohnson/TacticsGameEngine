using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Engine.Interfaces;

namespace TacticsGame.Engine.Models.UIElements
{
    public class UIText : IUIText
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public IntVector2 Position { get; set; }
        public int FontSize { get; set; }

        public UIText(string text, Color color, IntVector2 position, int fontSize)
        {
            Text = text;
            Color = color;
            Position = position;
            FontSize = fontSize;
        }

        public void DrawText()
        {
            Raylib.DrawText(Text, Position.X, Position.Y, FontSize, Color);
        }

        public void SetCenterPivot(int recW, int recY)
        {
            int textWidth = Raylib.MeasureText(Text, FontSize);
            Position = new IntVector2(Position.X - textWidth / 2, Position.Y);
        }
    }
}
