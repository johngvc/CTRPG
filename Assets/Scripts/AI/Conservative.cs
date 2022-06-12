using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Conservative : IControllingEntity
{
    AttackableEntity Self;
    List<AttackableEntity> OppositeParty;
    List<AttackableEntity> SameParty;

    GameController GameController;
    public void Init(AttackableEntity self, GameController gameController)
    {
        Self = self;
        GameController = gameController;
    }

    public void RefreshBattleEntities() {
        if (Self.Type == AttackableEntityType.Player)
        {
            OppositeParty = GameController.GetAllEnemies();
            SameParty = GameController.GetAllPlayers();
        } 
        else
        {
            OppositeParty = GameController.GetAllPlayers();
            SameParty = GameController.GetAllEnemies();
        }
    }

    public void CalculateNextMove()
    {   
        RefreshBattleEntities();
        var activeOppositeParty = aliveEntities(OppositeParty); 
        int randomIndex = Random.Range(0, activeOppositeParty.Count - 1);
        var randomTarget = activeOppositeParty[randomIndex];

        Debug.Log($"{Self.EntityName} Attacks {randomTarget.EntityName}!");
        Self.Actions[0].Execute(origin: Self, target: randomTarget);
    }

    private List<AttackableEntity> aliveEntities(List<AttackableEntity> entities)
    {
        var source = entities.Where(entity => entity.Alive);
        return new List<AttackableEntity>(source);
    }
}
