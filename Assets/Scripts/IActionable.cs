using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionable
{
    void execute(AttackableEntity target, AttackableEntity origin);
}
