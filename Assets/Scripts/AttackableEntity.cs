using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableEntity : GameEntity
{
    public int Hp;
    public int Sp;
    public int Atk;
    public int Matk;
    public int Initiative;
    public bool Alive;
    public List<IActionable> Actions;

    public AttackableEntity(Dictionary<string, dynamic> characterStats)
    {
        Hp = characterStats["Hp"];
        Sp = characterStats["Sp"];
        Initiative = characterStats["Initiative"];
        Atk = characterStats["Atk"];
        Matk = characterStats["Matk"];
        Actions = characterStats["Actions"];
        Alive = true;
    }

    public void TakeDamage(int damage) 
    {
        Hp -= damage;

        Debug.Log($"{EntityName} took {damage} damage points. Remaining Hp: {Hp}");

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
        Debug.Log($"You've defeated {EntityName}");
        Alive = false;
    }
}
