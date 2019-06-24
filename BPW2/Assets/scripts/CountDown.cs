using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountDown : MonoBehaviour
{
    public GameObject enemySpawn;
    public float timeLeft = 50; //Seconds Overall
    public Text countdown; //UI Text Object

    public GameObject finishScreen;
    public Text finishText;
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        
        countdown.text = ("" + Mathf.Floor(timeLeft)); //Showing the Score on the Canvas
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

        finishScreen.SetActive(true);
        finishText.text = " You killed " + ScoreObject.instance.score + " Ghosts.";
    }
}