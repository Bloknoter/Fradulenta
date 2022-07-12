using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Maps.Data;

public class BuildersSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject BuilderPrefab;

    [SerializeField]
    private MovingSpaceData SpaceData;

    void Start()
    {
        for(int i = 0; i < 25;i++)
        {
            GameObject builder = Instantiate(BuilderPrefab);
            builder.transform.position = SpaceData.GetRandomPoint();
        }
    }
}
