using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanWinObserver : MonoBehaviour
{
    [SerializeField]
    private Spy spy;

    [SerializeField]
    private Timer timer;

    

    public bool HasWon { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        if(spy.CurrentCivilState == Civil.state.Bearrested)
        {
            HasWon = true;
            //Debug.Log("Policeman wins, has arrested spy");
        }
        if (timer.TimeLeft == 0)
        {
            HasWon = true;
            //Debug.Log("Policeman wins, time has gone");
        }
    }

    
}
