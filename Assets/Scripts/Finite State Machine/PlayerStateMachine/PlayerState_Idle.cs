using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 5f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        if (input.IsMove)
        {
            stateMachine.SwitchState(typeof(PlayerState_Walk));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }

    public override void PhysicsUpdate()
    {
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
