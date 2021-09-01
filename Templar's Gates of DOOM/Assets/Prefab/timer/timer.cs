using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
 

public class timer : MonoBehaviour
{

    private string nomeCena;

    public Text timeLevel_txt;
    private float timeLevel;
    public static bool stopTime;
    void Start()
    {
        stopTime = false;
        timeLevel = 10 + GameManager.instance.level; 
        nomeCena = SceneManager.GetActiveScene().name;
    }

    
    void Update()
    {
        if(timeLevel <= 0) {
            stopTime = true;
        }

        if(stopTime==false)
        {
          timeLevel = timeLevel - Time.deltaTime;
          timeLevel_txt.text = timeLevel.ToString("F0");
        }
        
    
        else if(timeLevel<PlayerPrefs.GetFloat(nomeCena) || PlayerPrefs.GetFloat(nomeCena)==0)
        {   
    
            PlayerPrefs.SetFloat(nomeCena, timeLevel);
            PlayerPrefs.Save();
        }
    }
}