using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreObject : MonoBehaviour
{

    public int score = 0;
    private Text text;


    public static ScoreObject instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void IncreaseScore()
    {
        score++;
        text.text = score.ToString();
    }
}
