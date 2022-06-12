using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem
{
    private List<AttackableEntity> TurnStack;

    private List<AttackableEntity> Characters;

    private int CurrentCharacter = 0;

    private GameController GameController;

    public TurnSystem(List<AttackableEntity> characters)
    {
        Characters = characters;
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
        BuildTurnStack();
    }

    public AttackableEntity GetCurrentCharacter() {
        return TurnStack[CurrentCharacter];
    }

    public void FinishCharacterTurn() {
        int stackCount = TurnStack.Count - 1;
        
        if (CurrentCharacter == stackCount)
        {
            CurrentCharacter = 0;
        } 
        else
        {
            CurrentCharacter++;
        }

        if (!GetCurrentCharacter().Alive) { FinishCharacterTurn(); }

        GameController.EventSystem.TurnFinished(GetCurrentCharacter().Id);
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
