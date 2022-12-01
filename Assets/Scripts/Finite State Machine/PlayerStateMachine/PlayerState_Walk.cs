using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerState/Walk", fileName = "PlayerState_Walk")]
public class PlayerState_Walk : PlayerState
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float acceleration = 5f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = walkSpeed;
    }

    public override void LogicUpdate()
    {
        if (!input.IsMove)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, walkSpeed, acceleration * Time.deltaTime);
    }

    public override void PhysicsUpdate()
    {
        player.Move(currentSpeed);
    }
}
