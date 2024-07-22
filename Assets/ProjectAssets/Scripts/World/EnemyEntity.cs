using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Game.World;
using UnityEngine;

namespace Game.World
{
    public class EnemyEntity : Entity
    {
        EnemyStateMachine _enemyStateMachine = new EnemyStateMachine();
        public float shotCooldown = 10;

        public void ChooseDirection(Entity entity, float dt)
        {
            _enemyStateMachine.Run(this, entity, dt);
        }

     
    }
}
