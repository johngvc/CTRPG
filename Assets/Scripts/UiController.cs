using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameController GameController;

    // Being initiated in the inspector
    public GameObject Player1EntityStat;
    public GameObject Player2EntityStat;
    public GameObject Player3EntityStat;
    public GameObject EnemyEntityStat;
    public GameObject Player1Img;
    public GameObject Player2Img;
    public GameObject Player3Img;
    public GameObject Enemy1Img;
    public GameObject Enemy2Img;
    public GameObject Enemy3Img;
    public GameObject Enemy4Img;
    public GameObject ActionList;
    public GameObject TurnDisplay;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();
    }

    void RefreshUI() {

        Player1EntityStat.transform.Find("HP").transform
                                    .Find("Dynamic Text")
                                    .GetComponent<TextMeshProUGUI>().text = $"{GameController.GetAllPlayers()[0].CurrentHp} / {GameController.GetAllPlayers()[0].MaxHp}";

        Player2EntityStat.transform.Find("HP").transform
                                    .Find("Dynamic Text")
                                    .GetComponent<TextMeshProUGUI>().text = $"{GameController.GetAllPlayers()[1].CurrentHp} / {GameController.GetAllPlayers()[1].MaxHp}";

        Player3EntityStat.transform.Find("HP").transform
                                    .Find("Dynamic Text")
                                    .GetComponent<TextMeshProUGUI>().text = $"{GameController.GetAllPlayers()[2].CurrentHp} / {GameController.GetAllPlayers()[2].MaxHp}";
        
         EnemyEntityStat.transform.Find("HP").transform
                                    .Find("Dynamic Text")
                                    .GetComponent<TextMeshProUGUI>().text = $"{GameController.GetAllEnemies()[0].CurrentHp} / {GameController.GetAllEnemies()[0].MaxHp}";

    }
}
