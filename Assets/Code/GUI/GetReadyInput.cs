using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using MenuEngine;

public class GetReadyInput : MonoBehaviour
{
    [SerializeField]
    private Text SpyReadyT;

    [SerializeField]
    private Text PolicemanReadyT;

    [SerializeField]
    private MenuController menuController;

    [SerializeField]
    private string Next;

    private enum NextTypeEnum
    {
        Page,
        Scene
    }

    [SerializeField]
    private NextTypeEnum NextType;

    private bool IsSpyReady;

    private bool IsPolicemanReady;

    public bool AreBothReady { get { return IsSpyReady && IsPolicemanReady; } }

    void Start()
    {
        SpyIsNotReady();
        PolicemanIsNotReady();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            SetPolicemanReady();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetSpyReady();
        }
    }

    private void SetSpyReady()
    {
        IsSpyReady = !IsSpyReady;
        if (IsSpyReady)
        {
            SpyIsReady();
        }
        else
        {
            SpyIsNotReady();
        }
        CheckBothAndMakeTransition();
    }

    private void SpyIsReady()
    {
        SpyReadyT.text = "Spy is ready!";
        SpyReadyT.color = Color.green;
    }

    private void SpyIsNotReady()
    {
        SpyReadyT.text = "Press space to get ready...";
        SpyReadyT.color = Color.white;
    }

    private void SetPolicemanReady()
    {
        IsPolicemanReady = !IsPolicemanReady;
        if(IsPolicemanReady)
        {
            PolicemanIsReady();
        }
        else
        {
            PolicemanIsNotReady();
        }
        CheckBothAndMakeTransition();
    }

    private void PolicemanIsReady()
    {
        PolicemanReadyT.text = "Policeman is ready!";
        PolicemanReadyT.color = Color.green;
    }

    private void PolicemanIsNotReady()
    {
        PolicemanReadyT.text = "Press mouse button to get ready...";
        PolicemanReadyT.color = Color.white;
    }


    private void CheckBothAndMakeTransition()
    {
        if(AreBothReady && Next != "")
        {
            if (NextType == NextTypeEnum.Page)
            {
                menuController.SetPage(Next);
            }
            else
            {
                SceneManager.LoadScene(Next, LoadSceneMode.Single);
            }
        }
    }
}
