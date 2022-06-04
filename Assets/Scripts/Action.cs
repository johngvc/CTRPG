using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : IActionable
{
    int SpCost;
    string Name;

    public Action(int spCost, string name)
    {
        SpCost = spCost;
        Name = name;
    }

    public void Execute(AttackableEntity target, AttackableEntity origin)
    {
        if (NotEnoughSp(origin)) { return; }
    }

    private bool NotEnoughSp(AttackableEntity origin)
    {
        return origin.Sp < SpCost;
    }
}
