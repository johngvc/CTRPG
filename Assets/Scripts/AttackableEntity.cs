using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableEntity : GameEntity
{
    public string Id;

    public AttackableEntityType Type;
    public int Hp;

    public int Sp;

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
        Hp = characterStats["Hp"];
        Sp = characterStats["Sp"];
        Initiative = characterStats["Initiative"];
        Atk = characterStats["Atk"];
        Matk = characterStats["Matk"];
        Actions = characterStats["Actions"];
        Id = System.Guid.NewGuid().ToString();
        Alive = true;

        ControllingEntity = characterStats["ControllingEntity"];
        ControllingEntity.Init(this, GameController);

        GameController.EventSystem.onTurnFinished += TakeAction;
    }

    public void TakeAction(string currentTurnEntityId) {
        if (this.Id == currentTurnEntityId)
        {
            ControllingEntity.CalculateNextMove();
        }
    }

    public void TakeDamage(int damage) 
    {
        Hp -= damage;

        Debug.Log($"{EntityName} took {damage} damage points. \n Remaining Hp: {Hp} \n Remaining Sp: {Sp}");

        if (Hp <= 0)
        {
            _die();
        }
    }

    public void DeduceSp(int spCost)
    {
        Sp -= spCost;
    }

    private void _die() 
    {
        Debug.Log($"{EntityName} was defeated!");
        Alive = false;
    }
}
