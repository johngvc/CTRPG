using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Command", menuName = "CTRPG/Command", order = 0)]

public class Action : ScriptableObject, IActionable
{
    public int SpCost;
    public string Name;

    public void Execute(AttackableEntity target, AttackableEntity origin)
    {
        if (NotEnoughSp(origin)) { return; }

        target.TakeDamage(origin.Atk);
        origin.DeduceSp(SpCost);
    }

    private bool NotEnoughSp(AttackableEntity origin)
    {
        return origin.Sp < SpCost;
    }
}
