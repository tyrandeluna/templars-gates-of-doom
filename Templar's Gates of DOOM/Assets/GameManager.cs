using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;
    public static GameManager instance = null;
    public BoardManager boardScript;

    private GameObject levelImage;
    private Text levelText;
    private Text gameOverText;
    private int level = 1;
    private bool doingSetup;
    
    void Awake() {
        if(instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    private void OnLevelWasLoaded(int index) {
        level++;

        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        gameOverText = GameObject.Find("gameOverText").GetComponent<Text>();
        levelText.text = "Level " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);

        boardScript.SetupScene(level);
    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        levelImage.SetActive(true);
    }

    public void HideLevelImage() {
        levelImage.SetActive(false);
        doingSetup = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
