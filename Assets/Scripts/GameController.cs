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
    public Dictionary<string, dynamic> Char1 = new Dictionary<string, dynamic>()
    {
        { "Hp", 100 },
        { "sp", 30 },
        { "Initiative", 15 },
        { "Atk", 15 },
        { "Matk", 10 },
        { "Actions", new List<IActionable> 
            {
                new Action(15, "Super normal sword attack")
            }
        }
    };

    public Dictionary<string, dynamic> Enemy1 = new Dictionary<string, dynamic>()
    {
        { "Hp", 1000 },
        { "sp", 3000 },
        { "Initiative", 155 },
        { "Atk", 25 },
        { "Matk", 20 },
        { "Actions", new List<IActionable> 
            {
                new Action(0, "Super hard boss attack") //TO-DO: binder error
            }
        }
    };

    public List<AttackableEntity> Enemies;

    public List<AttackableEntity> Players;

    public GameStates GameState;

    public GameObject AttackableEntity;

    // Start is called before the first frame update
    void Start()
    {
        GameState = GameStates.StartScreen;

        Enemies.Add(new AttackableEntity(Enemy1));
        Players.Add(new AttackableEntity(Char1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
