using System;
using TacticsGame.Engine.Models;

namespace TacticsGame.Engine.Interfaces
{
    public interface IUIButton
    {
        public void OnClick();
        public void SetCenterPivot();
        public bool WasClicked(IntVector2 nmousePos);
    }
}

