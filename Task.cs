using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    interface ICapture
    {
        int Owner { get; set; }
    }

    interface IFight
    {
        Army Army { get; set; }
    }

    interface ICollect
    {
        Treasure Treasure { get; set; }
    }

    public class Dwelling : ICapture
    {
        public int Owner { get; set; }
    }

    public class Mine : ICapture, ICollect, IFight
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Creeps : IFight, ICollect
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Wolfs : IFight
    {
        public Army Army { get; set; }
    }

    public class ResourcePile : ICollect
    {
        public Treasure Treasure { get; set; }
    }

    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            if (mapObject is IFight)
                if (!player.CanBeat((mapObject as IFight).Army))
                {
                    player.Die();
                    return;
                }
            if (mapObject is ICapture) (mapObject as ICapture).Owner = player.Id;
            if (mapObject is ICollect) player.Consume((mapObject as ICollect).Treasure);
        }
    }
}
