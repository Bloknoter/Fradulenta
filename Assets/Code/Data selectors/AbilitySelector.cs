using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AbilityEngine;

public class AbilitySelector : MonoBehaviour
{
    [SerializeField]
    private Text AbilityNameT;

    [SerializeField]
    private Text AbilityDescriptionT;

    [SerializeField]
    private AbilityDatabase abilityDatabase;

    public AbilityData CurrentAbilityData
    {
        get { return abilityDatabase.abilityDatas[abilityDatabase.CurrentAblilityDataID]; }
    }

    void Start()
    {
        UpdateGUI();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            abilityDatabase.CurrentAblilityDataID--;
            if(abilityDatabase.CurrentAblilityDataID < 0)
            {
                abilityDatabase.CurrentAblilityDataID = abilityDatabase.abilityDatas.Length - 1;
            }
            UpdateGUI();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            abilityDatabase.CurrentAblilityDataID++;
            if (abilityDatabase.CurrentAblilityDataID > abilityDatabase.abilityDatas.Length - 1)
            {
                abilityDatabase.CurrentAblilityDataID = 0;
            }
            UpdateGUI();
        }
    }

    private void UpdateGUI()
    {
        AbilityNameT.text = abilityDatabase.abilityDatas[abilityDatabase.CurrentAblilityDataID].Name;
        AbilityDescriptionT.text = abilityDatabase.abilityDatas[abilityDatabase.CurrentAblilityDataID].Description;
    }
}
