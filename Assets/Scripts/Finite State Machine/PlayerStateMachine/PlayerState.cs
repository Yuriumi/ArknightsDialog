using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected float currentSpeed;
    [SerializeField] string stateName;
    [SerializeField, Range(0, 1f)] float transitionDuration = 0.1f;
    int stateHash;

    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerInput input;
    protected PlayerController player;

    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public void Initialize(Animator animator, PlayerController player, PlayerStateMachine stateMachine, PlayerInput input)
    {
        this.animator = animator;
        this.input = input;
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        
    }
}
