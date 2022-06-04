using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : IActionable
{
    int _SpCost;
    string _Name;

    public Action(int SpCost, string Name)
    {
        _SpCost = SpCost;
        _Name = Name;
    }

    public void Execute(AttackableEntity target, AttackableEntity origin)
    {
        if (NotEnoughSp(origin)) { return; }
    }

    private bool NotEnoughSp(AttackableEntity origin)
    {
        return origin.Sp < _SpCost;
    }
}
