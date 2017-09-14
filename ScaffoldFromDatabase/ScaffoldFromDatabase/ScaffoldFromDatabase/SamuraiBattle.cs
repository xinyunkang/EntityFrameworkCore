using System;
using System.Collections.Generic;

namespace ScaffoldFromDatabase
{
    public partial class SamuraiBattle
    {
        public int BattleId { get; set; }
        public int SamuraiId { get; set; }

        public virtual Battles Battle { get; set; }
        public virtual Samurai Samurai { get; set; }
    }
}
