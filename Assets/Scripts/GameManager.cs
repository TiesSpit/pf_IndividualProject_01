using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text HealthText;

    //Source: https://www.youtube.com/watch?v=9ocvKvJMKPs
    //--->
    [SerializeField] private int startScore = 0;
    private static int score = 0;
    //<---

    //Make this health match currentPlayerHealth from Damagable script 
    private int health = 100; 

    public static GameManager instance;

     private void Awake()
     {
        instance = this;
     }

    //This adds a call to this method to the context menu in the GameManager inspector
    [ContextMenu("Start game!")]
    
    //Public so that it can be accesed from outside this script
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");

        score = startScore;

        //UpdateScore(score);
        //UpdateHealth(health);              
    }

    //Public so that it can be accesed from outside this script
    public void ObjectWasDestroyed(GameObject go)
    {
        //Debug.Log("Object was destroyed: " + go.name);

        // Enemy destroyed?
        if (go.GetComponent<Enemy>() != null)
        {
            UpdateScore(score + 1);
        }
        // Player destroyed?
        else if (go.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("Switch to end scene");
            //Source: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
            //--->
            SceneManager.LoadScene("EndScene");
            //<---
            UpdateScore(score);
        }
    }

    //Source: https://www.youtube.com/watch?v=pz98OtOid5U
    //--->
    public void PlayerHealthChanged(Damagable damagable)
    {        
        health = damagable.currentPlayerHealth;
        UpdateHealth(health);
    }
    //<---

    private void UpdateScore(int pScore)
    {
        score = pScore;
        ScoreText.text = "Score: " + score;
    }

    private void UpdateHealth(int pHealth)
    {
        health = pHealth;
        HealthText.text = "Health: " + health;
    }

}
