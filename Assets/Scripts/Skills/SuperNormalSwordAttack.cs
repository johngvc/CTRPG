using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperNormalSwordAttack : EntityAction, IActionable
{
    public SuperNormalSwordAttack()
    {
        SpCost = 0;
        Name = "Super Normal Sword Attack";
    }

    public void Execute(AttackableEntity target, AttackableEntity origin)
    {
        base.Compute(target, origin, (target, origin) => {
            var atk = origin.Atk;

            int damage = atk * ( atk / 10 );

            target.TakeDamage(damage);
        });
    }
}
