using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperNormalSwordAttack : Action
{
    public SuperNormalSwordAttack()
    {
        SpCost = 10;
        Name = "Super Normal Sword Attack";
    }
    public override void Execute(AttackableEntity target, AttackableEntity origin)
    {
        base.Execute(target, origin);

        var atk = origin.Atk;

        int damage = atk * ( atk / 10 );

        target.TakeDamage(damage);
    }
}
