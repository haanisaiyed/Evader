using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int lives = 10;
    public float sceneSwitchTime = 20.0f;
    float switchTimer;
    public int sceneIndex;
    
    Text tex;
    // Start is called before the first frame update
    void Start()
    {
        tex = FindObjectOfType<Text>();
        switchTimer=sceneSwitchTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        tex.text = "Lives: " +lives.ToString(); 
        if(lives <1){
            SceneManager.LoadScene(5);
        }
        
        switchTimer-= Time.deltaTime;
        if(switchTimer<=0 && lives>0 && sceneIndex==5){
            SceneManager.LoadScene(6);
        }
        else if(switchTimer<=0)
        {
            SceneManager.LoadScene(sceneIndex);
            switchTimer = sceneSwitchTime;
        }


        
    }
    public void loseLife(){
        lives--;
        Debug.Log("Lives : " +lives);
    }
}
