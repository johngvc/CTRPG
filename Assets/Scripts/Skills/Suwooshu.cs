using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suwooshu : EntityAction, IActionable
{
    public Suwooshu()
    {
        SpCost = 0;
        Name = "Suwooshu";
    }
    public void Execute(AttackableEntity target, AttackableEntity origin)
    {
        base.Compute(target, origin, (target, origin) => {
            int damage = 999;

            target.TakeDamage(damage);
        });
    }
}

