using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    [SerializeField]
    private Text MapNameT;

    [SerializeField]
    private Maps.Data.MapsDatabase mapsDatabase;

    private int currentMapDataID;

    public Maps.Data.MapData CurrentMapData
    {
        get { return mapsDatabase.mapDatas[currentMapDataID]; }
    }

    void Start()
    {
        
    }

    private bool wasChanged;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") == 0f)
        {
            wasChanged = false;
        }
        if (!wasChanged)
        {
            if (Input.GetAxis("Mouse ScrollWheel") == 0.1f)
            {
                wasChanged = true;
                currentMapDataID++;
                if(currentMapDataID > mapsDatabase.mapDatas.Length - 1)
                {
                    currentMapDataID = 0;
                }
                UpdateGUI();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") == -0.1f)
            {
                wasChanged = true;
                currentMapDataID--;
                if (currentMapDataID < 0)
                {
                    currentMapDataID = mapsDatabase.mapDatas.Length - 1;
                }
                UpdateGUI();
            }
        }
    }

    private void UpdateGUI()
    {
        MapNameT.text = CurrentMapData.Name;
    }
}
