using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerObserver : MonoBehaviour
{
    [SerializeField]
    private PolicemanWinObserver policemanWinObserver;

    [SerializeField]
    private SpyWinObserver spyWinObserver;

    [SerializeField]
    private WinPanel winPanel;

    private enum WinnerEnum
    {
        None,
        Policeman,
        Spy
    }

    private WinnerEnum winner = WinnerEnum.None;

    void Start()
    {
        
    }

    void Update()
    {
        if(winner == WinnerEnum.None)
        {
            if(policemanWinObserver.HasWon)
            {
                winner = WinnerEnum.Policeman;
                StartCoroutine(Winning());
            }
            if (spyWinObserver.HasWon)
            {
                winner = WinnerEnum.Spy;
                StartCoroutine(Winning());
            }
        }
    }

    private IEnumerator Winning()
    {
        yield return new WaitForSeconds(5f);
        if (winner == WinnerEnum.Policeman)
            winPanel.PolicemanWin();
        else
            winPanel.SpyWin();
    }
}
