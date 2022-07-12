using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyWinObserver : MonoBehaviour
{
    [SerializeField]
    private C4PlaceSpawner C4Placespawner;

    [SerializeField]
    private GameObject DissappearingWalls;

    [SerializeField]
    private Spy spy;

    [SerializeField]
    private Policeman policeman;

    private int C4amountleft;

    public bool HasWon { get; private set; }



    void Start()
    {
        for (int i = 0; i < C4Placespawner.C4PlaceObjects.Length; i++)
        {
            C4Placespawner.C4PlaceObjects[i].GetComponent<C4Place>().OnC4PlacedEvent += OnC4Placed;
        }
        C4amountleft = C4PlaceSpawner.C4_AMOUNT;
    }

    void Update()
    {
        if(spy.HasLeftLocation)
        {
            HasWon = true;
            //Debug.Log("Spy wins, has put all C4 and left the location");
        }
        if (policeman.ManaclesCount == 0)
        {
            HasWon = true;
            //Debug.Log("Spy wins, policeman has wasted all his manacles");
        }
    }

    private void OnC4Placed()
    {
        C4amountleft--;
        if (C4amountleft == 0)
            Destroy(DissappearingWalls);
    }
        
}
