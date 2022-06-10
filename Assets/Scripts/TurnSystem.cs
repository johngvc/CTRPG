using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem
{
    private List<AttackableEntity> TurnStack;

    private List<AttackableEntity> Characters;

    private int currentCharacter = 0;

    public TurnSystem(List<AttackableEntity> characters)
    {
        Characters = characters;
        BuildTurnStack();
    }

    public AttackableEntity GetCurrentCharacter() {
        return TurnStack[currentCharacter];
    }

    public void FinishCharacterTurn() {
        int stackCount = TurnStack.Count - 1;
        
        if (currentCharacter == stackCount)
        {
            currentCharacter = 0;
        } 
        else
        {
            currentCharacter++;
        }

        if (!GetCurrentCharacter().Alive) { FinishCharacterTurn(); }
    }

    public List<AttackableEntity> GetTurnStack() {
        return TurnStack;
    }
    private void BuildTurnStack() {
        TurnStack = new List<AttackableEntity>(Characters);
        TurnStack.Sort((char1, char2) => char1.Initiative.CompareTo(char2.Initiative));
    }

    private void RecalculateTurnStack() {
        // Let's implement this when we refactor the turn system
    }
}
