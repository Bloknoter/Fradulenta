using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaclesDisplay : MonoBehaviour
{
    [SerializeField]
    private Policeman policeman;

    [SerializeField]
    private Text manaclesamountT;

    void Start()
    {
        
    }

    void Update()
    {
        manaclesamountT.text = policeman.ManaclesCount.ToString();
    }
}
