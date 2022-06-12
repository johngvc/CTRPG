using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllingEntity
{
    public void Init(AttackableEntity self, GameController gameController);
    public void CalculateNextMove();
}
