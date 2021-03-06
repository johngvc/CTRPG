using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum AttackableEntityType
    {
        Player,
        Enemy
    }

public enum GameState
    {
        StartScreen,
        Battle,
        GameOver
    }
public class GameController : MonoBehaviour
{
    public List<GameObject> Enemies;

    public List<GameObject> Players;

    public GameState CurrentGameState;

    public GameObject AttackableEntityPrefab;

    public Vector3 DefaultPosition = new Vector3(0, 0, 0);

    public Quaternion DefaultRotation = Quaternion.identity;

    public TurnSystem TurnSystem;

    public GameEvents EventSystem;

    

    

    //MOCK
    public Dictionary<string, dynamic> char1 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Player One"},
        { "Type", AttackableEntityType.Player },
        { "MaxHp", 100 },
        { "MaxSp", 30 },
        { "Initiative", 15 },
        { "Atk", 20 },
        { "Matk", 10 },
        { "Actions", new List<IActionable> 
            {
                new SuperNormalSwordAttack() 
            }
        },
        { "ControllingEntity", new Conservative() }
    };

    public Dictionary<string, dynamic> enemy1 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Enemy One"},
        { "Type", AttackableEntityType.Enemy },
        { "MaxHp", 250 },
        { "MaxSp", 3000 },
        { "Initiative", 155 },
        { "Atk", 15 },
        { "Matk", 20 },
        { "Actions", new List<IActionable> 
            {
                new SuperBallOfDestruction() 
            }
        },
        { "ControllingEntity", new Conservative() }
    };

    public Dictionary<string, dynamic> char2 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Player Two"},
        { "Type", AttackableEntityType.Player },
        { "MaxHp", 240 },
        { "MaxSp", 30 },
        { "Initiative", 15 },
        { "Atk", 20 },
        { "Matk", 10 },
        { "Actions", new List<IActionable> 
            {
                new SuperBallOfDestruction() 
            }
        },
        { "ControllingEntity", new Conservative() }
    };

    public Dictionary<string, dynamic> enemy2 = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Enemy Two"},
        { "Type", AttackableEntityType.Enemy },
        { "MaxHp", 150 },
        { "MaxSp", 3000 },
        { "Initiative", 155 },
        { "Atk", 15 },
        { "Matk", 20 },
        { "Actions", new List<IActionable> 
            {
                new SuperBallOfDestruction() 
            }
        },
        { "ControllingEntity", new Conservative() }
    };

    public Dictionary<string, dynamic> ControllingPlayer = new Dictionary<string, dynamic>()
    {
        { "EntityName", "Player Three"},
        { "Type", AttackableEntityType.Player },
        { "MaxHp", 20000 },
        { "MaxSp", 3000 },
        { "Initiative", 250 },
        { "Atk", 15 },
        { "Matk", 20 },
        { "Actions", new List<IActionable> 
            {
                new SuperBallOfDestruction(),
                new Suwooshu()
            }
        },
        { "ControllingEntity", null }
    };

    // Start is called before the first frame update
    void Start()
    {
        CurrentGameState = GameState.Battle;
        EventSystem = new GameEvents();

        mockEnemies();
        TurnSystem = new TurnSystem(GetAllCharacters());

        EventSystem.TurnFinished(TurnSystem.GetCurrentCharacter().Id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool OpposingPartyIsDefeated(AttackableEntityType type) {
        if (type == AttackableEntityType.Player)
        {
            return GetAllEnemies().TrueForAll((AttackableEntity) => AttackableEntity.Alive == false);
        }

        return  GetAllPlayers().TrueForAll((AttackableEntity) => AttackableEntity.Alive == false);
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
        Players.Add(_instantiateAndInitializePrefab(
                            prefab: AttackableEntityPrefab,
                            initialArgs: char2,
                            position: DefaultPosition,
                            rotation: DefaultRotation
                           ));

        Enemies.Add(_instantiateAndInitializePrefab(
                            prefab: AttackableEntityPrefab,
                            initialArgs: enemy2,
                            position: DefaultPosition,
                            rotation: DefaultRotation
                           ));
        Players.Add(_instantiateAndInitializePrefab(
                            prefab: AttackableEntityPrefab,
                            initialArgs: ControllingPlayer,
                            position: DefaultPosition,
                            rotation: DefaultRotation
                           ));  
    }

    public List<AttackableEntity> GetAllEnemies()
    {
        return ConvertGameObjectToComponent(Enemies);
    }
    public List<AttackableEntity> GetAllPlayers()
    {
        return ConvertGameObjectToComponent(Players);
    }

    public List<AttackableEntity> GetAllCharacters() {
        var allCharacters = new List<AttackableEntity>(Players.Count + Enemies.Count);
        allCharacters.AddRange(GetAllEnemies());
        allCharacters.AddRange(GetAllPlayers());
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
