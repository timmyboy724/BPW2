using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private followWaypoint wayPoint;
    private States enemyState;
    private float timer = 2;
    private bool startTimer;

    private void Start()
    {
        wayPoint = GetComponent<followWaypoint>();    
    }

    private void Update()
    {
        switch (enemyState)
        {
            case States.Green:
                //Changing color to Green
                wayPoint.ChangeColor(States.Green);
                startTimer = true;

                //Starting timer
                if (Timer() < 0)
                {
                    NewState(States.Red);
                    startTimer = false;
                    timer = 2;
                }
                break;
            case States.Red:
                //Changing Color red
                wayPoint.ChangeColor(States.Red);
                startTimer = true;

                //Starting timer
                if (Timer() < 0)
                {
                    NewState(States.Blue);
                    startTimer = false;
                    timer = 2;
                }
                break;
            case States.Blue:
                //Changing color to blue
                wayPoint.ChangeColor(States.Blue);
                startTimer = true;

                //Starting timer
                if (Timer() < 0)
                {
                    NewState(States.Green);
                    startTimer = false;
                    timer = 2;
                }
                break;
        }
    }

    //Timer
    public float Timer()
    {
        return timer -= Time.deltaTime;
    }

    //Changing states
    public void NewState(States state)
    {
        enemyState = state;
    }

}
public enum States
{
    Green, //0
    Red,   //1
    Blue   //2
}