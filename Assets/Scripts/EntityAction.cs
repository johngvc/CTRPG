using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAction
{
    public int SpCost;
    public string Name;

    private GameController GameController;

    public virtual void Compute(AttackableEntity target, AttackableEntity origin, Action<AttackableEntity, AttackableEntity> skillFormula){
        GameController = GameObject.Find("GameController").GetComponent<GameController>();

        if (_notEnoughSp(origin)) { return; }

        origin.DeduceSp(SpCost);

        skillFormula(target, origin);


        if (GameController.OpposingPartyIsDefeated(origin.Type))
        {
            Debug.Log($"{origin.EntityName} did the last blow! And the {origin.Type.ToString() + 's'} WON!");
            GameController.CurrentGameState = GameState.GameOver;
            return;
        }
        
        GameController.TurnSystem.FinishCharacterTurn();
    }

    protected bool _notEnoughSp(AttackableEntity origin)
    {
        return origin.CurrentSp < SpCost;
    }
}
