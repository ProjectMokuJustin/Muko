﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{

    private int xInput;

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;

        if (shouldCheckFlip)
        {
            core.Movement.CheckIfShouldFlip(xInput);
        }


        if (setVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * core.Movement.FacingDirection);
        }
    }


    public void SetPlayerVelocity(float velocity)
    {
        core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    #region Animation Triggers

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();                

        isAbilityDone = true;
    }

    #endregion
}
