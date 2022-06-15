using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableEntity : GameEntity
{
    public string Id;

    public AttackableEntityType Type;
    public int CurrentHp;

    public int MaxHp;

    public int CurrentSp;

    public int MaxSp;

    public int Atk;

    public int Matk;

    public int Initiative;

    public bool Alive;

    public List<IActionable> Actions;

    public IControllingEntity ControllingEntity;

    public GameController GameController;

    public void Init(Dictionary<string, dynamic> characterStats)
    {   
        GameController = GameObject.Find("GameController").GetComponent<GameController>();

        EntityName = characterStats["EntityName"];
        Type = characterStats["Type"];
        MaxHp = characterStats["MaxHp"];
        MaxSp = characterStats["MaxSp"];
        CurrentHp = MaxHp;
        CurrentSp = MaxSp;
        Initiative = characterStats["Initiative"];
        Atk = characterStats["Atk"];
        Matk = characterStats["Matk"];
        Actions = characterStats["Actions"];
        Id = System.Guid.NewGuid().ToString();
        Alive = true;

        ControllingEntity = characterStats["ControllingEntity"];
        if (ControllingEntity != null) 
        {
            ControllingEntity.Init(this, GameController);
            GameController.EventSystem.onTurnFinished += TakeAction;
        }
    }

    public void TakeAction(string currentTurnEntityId) {
        if (this.Id == currentTurnEntityId)
        {
            ControllingEntity.CalculateNextMove();
        }
    }

    public void TakeDamage(int damage) 
    {
        CurrentHp -= damage;

        Debug.Log($"{EntityName} took {damage} damage points. \n Remaining Hp: {CurrentHp} \n Remaining Sp: {CurrentSp}");

        if (CurrentHp <= 0)
        {
            _die();
        }
    }

    public void DeduceSp(int spCost)
    {
        CurrentSp -= spCost;
    }

    private void _die() 
    {
        Debug.Log($"{EntityName} was defeated!");
        Alive = false;
    }
}
