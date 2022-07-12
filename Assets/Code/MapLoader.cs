using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    [SerializeField]
    private MapSelector mapSelector;

    [SerializeField]
    private GetReadyInput lastReady;

    void Start()
    {
        
    }

    private bool wasloading;

    void Update()
    {
        if(lastReady.AreBothReady)
        {
            if (!wasloading)
            {
                wasloading = true;
                SceneManager.LoadScene(mapSelector.CurrentMapData.SceneName);
            }
        }
    }
}
