﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShakeAndBake.Model.GameEntity;

namespace ShakeAndBake.Classes.Model.EnemyFactory
{
    class MidBossEnemyFactory
    {
        public Enemy create()
        {
            return new MidBoss();
        }
    }
}
