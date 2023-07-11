using System;
namespace TacticsGame.Source.Interfaces
{
    public interface IUIButton
    {
        public void OnClick();
        public void SetCenterPivot();
        public void WasClicked();
    }
}

