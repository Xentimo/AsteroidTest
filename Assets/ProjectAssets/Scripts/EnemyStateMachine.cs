using System.Collections;
using System.Collections.Generic;
using Game.World;
using UnityEngine;


public class EnemyStateMachine 
{
    public AttackState attackState;
    public RetriteState retriteState;
    StateBase _currentState;

    public EnemyStateMachine()
    {
        attackState = new AttackState(this);
        retriteState = new RetriteState(this);
        _currentState = attackState;
    }

    public void Run(EnemyEntity enemyEntity, Entity entity, float dt)
    {
        _currentState = _currentState.Handle(enemyEntity, entity, dt);
    }
}

public abstract class StateBase
{
    protected EnemyStateMachine enemyStateMachine;
    public StateBase(EnemyStateMachine enemyStateMachine)
    {
        this.enemyStateMachine = enemyStateMachine;
    }

    public abstract StateBase Handle(EnemyEntity me, Entity target, float dt);
}

public class AttackState : StateBase
{

    public AttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    { }

    public override StateBase Handle(EnemyEntity me, Entity target, float dt)
    {
        var toTarget = (target.position - me.position);
        if (me.shotCooldown < 7 || toTarget.magnitude < 2)
        {
            return enemyStateMachine.retriteState;
        }
        
        var toTargetDirNorm = toTarget.normalized;
        me.moment  = 2*Vector3.SignedAngle(me.direction, toTargetDirNorm, Vector3.back) * dt;
        me.direction = Quaternion.Euler(0, 0, - me.moment ) * me.direction;
        return this;
    }
}

public class RetriteState : StateBase
{
    public RetriteState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override StateBase Handle(EnemyEntity enemy, Entity target, float dt)
    {
        var toTarget = (target.position - enemy.position);
        if (toTarget.magnitude > 5 && enemy.shotCooldown > 7)
        {
            return enemyStateMachine.attackState;
        }

        var toTargetDirNorm = toTarget.normalized;
        Vector3 retreatDir = -toTargetDirNorm + new Vector3(toTargetDirNorm.x, -toTargetDirNorm.y, 0);
        enemy.moment = 0.2f*Vector3.SignedAngle(enemy.direction, retreatDir, Vector3.back) * dt;
        enemy.direction = Quaternion.Euler(0, 0, - enemy.moment ) *   enemy.direction;
        return this;
    }
}


