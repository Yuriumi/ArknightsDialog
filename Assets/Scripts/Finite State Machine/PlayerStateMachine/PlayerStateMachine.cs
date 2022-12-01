using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] private PlayerState[] states;

    private Animator animator;
    private PlayerInput input;
    protected PlayerController player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();
        stateList = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(animator, player, this, input);
            stateList.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        SwitchOn(stateList[typeof(PlayerState_Idle)]);
    }
}
