using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class searchState : BaseState
{
    private float searchTimer;
    private float moveTimer;

    public override void Enter()
    {
       enemy.Agent.SetDestination(enemy.LastKnowPos);
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
            StateMachine.ChangeState(new attack_state());

        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer =+ Time.deltaTime;
            moveTimer = Time.deltaTime;
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            if (searchTimer > 10)
            {
                StateMachine.ChangeState(new patrol_state());
            }
        }
    }
    public override void Exit()
    {

    }


}
