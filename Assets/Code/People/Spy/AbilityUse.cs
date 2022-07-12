using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbilityEngine
{
    public class AbilityUse : MonoBehaviour
    {
        [SerializeField]
        private AbilityDatabase abilityDatabase;

        [SerializeField]
        private GameObject Player;

        private Ability ability;

        private bool hasused;

        void Start()
        {
            GameObject abilityobj = Instantiate(abilityDatabase.abilityDatas[abilityDatabase.CurrentAblilityDataID].AbilityPrefab);
            ability = abilityobj.GetComponent<Ability>();
            ability.Player = Player;
        }

        void Update()
        {

        }

        public void Use()
        {
            if (!hasused)
            {
                hasused = true;
                ability.Use();
            }
        }
            
    }
}
