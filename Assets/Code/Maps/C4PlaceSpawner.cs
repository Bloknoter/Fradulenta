using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4PlaceSpawner : MonoBehaviour
{
    public const int C4_AMOUNT = 3;

    [SerializeField]
    private Transform[] C4Places;

    [SerializeField]
    private GameObject C4PlacePrefab;

    public GameObject[] C4PlaceObjects { get; private set; }

    private void OnEnable()
    {
        List<Transform> points = new List<Transform>(C4Places);
        C4PlaceObjects = new GameObject[C4_AMOUNT];
        for (int i = 0; i < C4_AMOUNT; i++)
        {
            int id = Random.Range(0, points.Count);
            GameObject c4place = Instantiate(C4PlacePrefab);
            c4place.transform.position = points[id].position;
            C4PlaceObjects[i] = c4place;
            points.RemoveAt(id);
        }
    }

    private void Start()
    {
   
    }

}
