using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public Action<string> onTurnFinished;

    public void TurnFinished(string id) {
        var gameController = GameObject.Find("GameController").GetComponent<GameController>();

        if (onTurnFinished != null && gameController.CurrentGameState == GameState.Battle) {
            onTurnFinished(id);
        }
    }
}
