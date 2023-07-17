using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Engine.Models;

namespace TacticsGame.Source.Entities.Models
{
    public class PlayerUnit
    {
        string Name { get; set; }
        string PlayerSpriteSrc { get; set; }
        List<IntVector2> Movement { get; set; }

        public PlayerUnit()
        {
            Name = "";
            PlayerSpriteSrc = "../../../Assets/Player_Sprite.png";
            Movement = new List<IntVector2>();
            Movement.Add(new IntVector2(0, 1));
            Movement.Add(new IntVector2(0, 2));
            Movement.Add(new IntVector2(0, -1));
            Movement.Add(new IntVector2(0, -2));
            Movement.Add(new IntVector2(1, 0));
            Movement.Add(new IntVector2(2, 0));
            Movement.Add(new IntVector2(-1, 0));
            Movement.Add(new IntVector2(-2, 0));
            Movement.Add(new IntVector2(1, 1));
            Movement.Add(new IntVector2(-1, 1));
            Movement.Add(new IntVector2(-1, -1));
            Movement.Add(new IntVector2(1, -1));

        }
    }
}
