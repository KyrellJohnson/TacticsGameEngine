using Raylib_cs;
using System;
using TacticsGame.Engine.Models;
using TacticsGame.Engine.Models.UIElements;

namespace TacticsGame.Engine.Interfaces
{
    public interface IUIButton
    {
        public void OnClick();
        public void SetCenterPivot();
        public void DrawButton();
        public void DrawButton(bool withText);
        public bool WasClicked(IntVector2 nmousePos);
    }
}

