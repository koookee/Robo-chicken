using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameHasStarted = false;
    public Text startingTutorial;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Ammo;
    public TextMeshProUGUI bossHP;
    public Button startButton;
    public Button restartButton;
    public GameObject OnScreenText;
    public GameObject OnScreenText2;
    public GameObject OnScreenText3;
    public GameObject OnScreenText4;
    public GameObject OnScreenText5;
    public GameObject Boss;
    public BossScript bossScript;
    public SpawnManager SpawnManagerScript;
    public PlayerController PlayerController;
    public int scoreVal;
    public Text win;
    public bool gameWon;
    public bool bossSpawned;
    // Start is called before the first frame update
    void Start()
    {

        PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        Boss.SetActive(false);
        gameWon = false;
    }
    public void startGame()
    {
        
        //Debug.Log("clicked the button");
        startingTutorial.gameObject.SetActive(false);
        gameHasStarted = true;
        PlayerController.isGamePaused = false;
    }
    public void restartGame()
    {
        restartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startingTutorial.gameObject.SetActive(true);
    }
    public void endGame()
    {
        bossHP.gameObject.SetActive(false);
        gameWon = true;
        win.gameObject.SetActive(true);
        
    }
    IEnumerator ShowText(int i)
    {
        if(i == 1) 
        {
            OnScreenText.SetActive(true);
            yield return new WaitForSeconds(5);//5
            OnScreenText.SetActive(false);
        }
        if(i == 2)
        {
            OnScreenText2.SetActive(true);
            yield return new WaitForSeconds(5);
            OnScreenText2.SetActive(false);
        }
        if (i == 3)
        {
            OnScreenText3.SetActive(true);
            yield return new WaitForSeconds(5);
            OnScreenText3.SetActive(false);
        }
        if(i == 4)
        {
            OnScreenText4.SetActive(true);
            yield return new WaitForSeconds(5);
            OnScreenText4.SetActive(false);
            OnScreenText5.SetActive(true);
            yield return new WaitForSeconds(7);
            OnScreenText5.SetActive(false);
            PlayerController.BossSpawned = true;
            SpawnManagerScript.BossSpawner();
        }


    }

    public void updateText()
    {
        Score.text = "Score: " + PlayerController.score;
        Ammo.text = "Ammo: " + PlayerController.ammo;
        
        /* if (bossScript.isBossAlive == true)
         {
             bossHP.gameObject.SetActive(true);
             bossHP.text = "Boss Health: " + bossScript.health;
         }
         */
        
    }
    public void OnScreen(int i)
    {
     StartCoroutine(ShowText(i));
    }
    // Update is called once per frame
    void Update()
    {
        updateText();
        if (PlayerController.gameOver == true)
        {
            restartButton.gameObject.SetActive(true);
        }
        
    }

}
