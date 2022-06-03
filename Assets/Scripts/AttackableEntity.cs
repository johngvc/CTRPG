using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableEntity : GameEntity
{
    public int hp;
    public int sp;
    public int atk;
    public int matk;
    public int initiative;
    public bool alive;
    public List<Action> _actions;

    public AttackableEntity(Dictionary<string, dynamic> characterStats, List<Action> actions)
    {
        hp = characterStats["hp"];
        sp = characterStats["sp"];
        initiative = characterStats["initiative"];
        atk = characterStats["atk"];
        matk = characterStats["matk"];
        _actions = actions;
        alive = true;

    }

    public void takeDamage(int damage) 
    {
        hp -= damage;

        Debug.Log($"{name} took {damage} damage points. Remaining hp: {hp}");

        if (hp <= 0)
        {
            die();
        }
    }

    public void deduceSp(int spCost)
    {
        sp -= spCost;
    }

    private void die() 
    {
        Debug.Log($"You've defeated {name}");
        alive = false;
    }
}
