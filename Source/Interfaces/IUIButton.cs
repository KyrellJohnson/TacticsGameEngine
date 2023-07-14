using System;
using TacticsGame.Source.Models;

namespace TacticsGame.Source.Interfaces
{
    public interface IUIButton
    {
        public void OnClick();
        public void SetCenterPivot();
        public bool WasClicked(IntVector2 nmousePos);
    }
}

