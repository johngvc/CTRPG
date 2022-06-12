using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBallOfDestruction : EntityAction, IActionable
{
    public SuperBallOfDestruction()
    {
        SpCost = 0;
        Name = "Super Ball Of Destruction";
    }
    public void Execute(AttackableEntity target, AttackableEntity origin)
    {
        base.Compute(target, origin, (target, origin) => {
            var atk = origin.Atk;

            int damage = (atk + (atk / 2)) * ( atk / 10 );

            target.TakeDamage(damage);
        });
    }
}
