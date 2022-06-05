using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<AttackableEntity> Enemies;

    public List<AttackableEntity> Players;

    public GameState CurrentGameState;

    public GameObject AttackableEntityPrefab;

    public Vector3 DefaultPosition = new Vector3(0, 0, 0);

    public Quaternion DefaultRotation = Quaternion.identity;

    public enum GameState
    {
        StartScreen,
        Battle,
        GameOver
    }

    //MOCK
    public Dictionary<string, dynamic> char1 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Player One"},
        { "Hp", 100 },
        { "Sp", 30 },
        { "Initiative", 15 },
        { "Atk", 15 },
        { "Matk", 10 },
        { "Actions", new List<IActionable> 
            {
                new Action(15, "Super normal sword attack")
            }
        }
    };

    public Dictionary<string, dynamic> enemy1 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Enemy One"},
        { "Hp", 1000 },
        { "Sp", 3000 },
        { "Initiative", 155 },
        { "Atk", 25 },
        { "Matk", 20 },
        { "Actions", new List<IActionable> 
            {
                new Action(0, "Super hard boss attack") //TO-DO: binder error
            }
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.StartScreen;

        var instantiatedAttackableEntity = Instantiate(AttackableEntityPrefab, DefaultPosition, DefaultRotation);
        
        var componentAttackableEntity = instantiatedAttackableEntity.GetComponent<AttackableEntity>() as AttackableEntity;

        Debug.Log(componentAttackableEntity.Hp);

        componentAttackableEntity.Init(char1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
