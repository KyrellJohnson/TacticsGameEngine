using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Engine.Models;

namespace TacticsGame.Engine.Interfaces
{
    internal interface IUIText
    {
        public string Text { get; set; }
        public Color Color { get; set; }
        public IntVector2 Position { get; set; }
        public int FontSize { get; set; }

        public void DrawText();
        public void SetCenterPivot();

    }
}
