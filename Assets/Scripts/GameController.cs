using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> Enemies;

    public List<GameObject> Players;

    public GameState CurrentGameState;

    public GameObject AttackableEntityPrefab;

    public Vector3 DefaultPosition = new Vector3(0, 0, 0);

    public Quaternion DefaultRotation = Quaternion.identity;

    public TurnSystem TurnSystem;

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
        { "Atk", 20 },
        { "Matk", 10 },
        { "Actions", new List<IActionable> 
            {
                new SuperNormalSwordAttack() 
            }
        }
    };

    public Dictionary<string, dynamic> enemy1 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Enemy One"},
        { "Hp", 1000 },
        { "Sp", 3000 },
        { "Initiative", 155 },
        { "Atk", 15 },
        { "Matk", 20 },
        { "Actions", new List<IActionable> 
            {
                new SuperBallOfDestruction() 
            }
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.StartScreen;

        mockEnemies();
        TurnSystem = new TurnSystem(GetAllCharacters());
        

        var player = Players[0].GetComponent<AttackableEntity>();
        var enemy = Enemies[0].GetComponent<AttackableEntity>();
        player.Actions[0].Execute(target: enemy, origin: player);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void mockEnemies() {
        // Delete this in the future

        Players.Add(_instantiateAndInitializePrefab(
                            prefab: AttackableEntityPrefab,
                            initialArgs: char1,
                            position: DefaultPosition,
                            rotation: DefaultRotation
                           ));

        Enemies.Add(_instantiateAndInitializePrefab(
                            prefab: AttackableEntityPrefab,
                            initialArgs: enemy1,
                            position: DefaultPosition,
                            rotation: DefaultRotation
                           ));        
    }

    private List<AttackableEntity> GetAllCharacters() {
        var allCharacters = new List<AttackableEntity>(Players.Count + Enemies.Count);
        allCharacters.AddRange(ConvertGameObjectToComponent(Players));
        allCharacters.AddRange(ConvertGameObjectToComponent(Enemies));
        return allCharacters;
    }

    private List<AttackableEntity> ConvertGameObjectToComponent(List<GameObject> gameObjectList)
    {
        var convertedObjects = gameObjectList.Select(x => x.GetComponent<AttackableEntity>());
        return new List<AttackableEntity>(convertedObjects);
    }

    private GameObject _instantiateAndInitializePrefab(
                                    GameObject prefab, 
                                    Dictionary<string, dynamic> initialArgs, 
                                    Vector3? position = null, 
                                    Quaternion? rotation = null
                                    )
    {
        var instantiatedGameObject = Instantiate(prefab, DefaultPosition, DefaultRotation);
        var gameObjectComponent = instantiatedGameObject.GetComponent<AttackableEntity>();

        gameObjectComponent.Init(initialArgs);

        return instantiatedGameObject;
    }
}
