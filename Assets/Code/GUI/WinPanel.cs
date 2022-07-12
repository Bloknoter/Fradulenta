using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MenuEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private MenuController menuController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PolicemanWin()
    {
        menuController.SetPage("Policeman win");
    }

    public void SpyWin()
    {
        menuController.SetPage("Spy win");
    }
}
