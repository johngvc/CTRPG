using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameStates
    {
        StartScreen,
        Battle,
        GameOver
    }

    //MOCK
    public Dictionary<string, dynamic> char1 = new Dictionary<string, dynamic>()
    {
        { "hp", 100 },
        { "sp", 30 },
        { "initiative", 15 },
        { "atk", 15 },
        { "matk", 10 },
        { "actions", new List<Action> 
            {
                new Action(15, "Super normal sword attack")
            }
        }
    };

    public Dictionary<string, dynamic> enemy1 = new Dictionary<string, dynamic>()
    {
        { "hp", 1000 },
        { "sp", 3000 },
        { "initiative", 155 },
        { "atk", 25 },
        { "matk", 20 },
        { "actions", new List<IActionable> 
            {
                new Action(0, "Super hard boss attack") //TO-DO: binder error
            }
        }
    };

    public List<AttackableEntity> Enemies;

    public List<AttackableEntity> Players;

    public GameStates gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameStates.StartScreen;

        Enemies.Add(new AttackableEntity(enemy1));
        Players.Add(new AttackableEntity(char1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
