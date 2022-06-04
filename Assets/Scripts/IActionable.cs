using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionable
{
    void Execute(AttackableEntity target, AttackableEntity origin);
}
