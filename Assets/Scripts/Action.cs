using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : IActionable
{
    public int SpCost;
    public string Name;

    public virtual void Execute(AttackableEntity target, AttackableEntity origin){
        if (_notEnoughSp(origin)) { return; }

        origin.DeduceSp(SpCost);
    }

    protected bool _notEnoughSp(AttackableEntity origin)
    {
        return origin.Sp < SpCost;
    }
}
