using Raylib_cs;
using TacticsGame.Engine.Interfaces;
using TacticsGame.Engine.Utilities;
using TacticsGame.Source.UserInterface;

namespace TacticsGame.Engine.Models.UIElements
{
    public class UIButton : IUIButton
    {
        public IntVector2 position { get; private set; }
        public IntVector2 size { get; private set; }
        public Color color { get; private set; }
        public UIText? text { get; private set; }

        public UIButton(IntVector2 position, IntVector2 size, Color color)
        {
            this.position = position;
            this.size = size;
            this.color = color;
        }

        public UIButton(IntVector2 position, IntVector2 size, Color color, UIText text)
        {
            this.position = position;
            this.size = size;
            this.color = color;
            this.text = text;
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }

        public void SetCenterPivot()
        {
            position = new IntVector2(position.X - size.X / 2, position.Y - size.Y / 2);
        }

        public bool WasClicked(IntVector2 mousePos)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(position.X, position.Y, size.X, size.Y);

            return MathUtils.RectangleContainsPoint(rectangle, mousePos);
        }

        public void DrawButton()
        {
            Raylib.DrawRectangle(position.X, position.Y, size.X, size.Y, color);
        }

        public void DrawButton(bool withText)
        {
            Raylib.DrawRectangle(position.X, position.Y, size.X, size.Y, color);
            if(text is not null) text.DrawText();
        }
    }

}
