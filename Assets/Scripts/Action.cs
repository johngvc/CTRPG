using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : IActionable
{
    int _spCost;
    string _name;

    public Action(int spCost, string name)
    {
        _spCost = spCost;
        _name = name;
    }

    public void execute(AttackableEntity target, AttackableEntity origin)
    {
        if (notEnoughSp(origin)) { return; }
    }

    private bool notEnoughSp(AttackableEntity origin)
    {
        return origin.sp < _spCost;
    }
}
