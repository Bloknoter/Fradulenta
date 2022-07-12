using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCostume : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer BodyImage;

    [SerializeField]
    private SpriteRenderer[] LegsImages;

    [SerializeField]
    private SpriteRenderer ToolImage;

    [SerializeField]
    private BuildreCostumeData[] costumes;

    [SerializeField]
    private Sprite[] tools;

    void Start()
    {
        BuildreCostumeData costume = costumes[Random.Range(0, costumes.Length)];
        BodyImage.sprite = costume.Body;
        for (int i = 0; i < LegsImages.Length; i++)
        {
            LegsImages[i].sprite = costume.Leg;
        }
        ToolImage.sprite = tools[Random.Range(0, tools.Length)];
    }

    void Update()
    {
        
    }
}

[System.Serializable]
public class BuildreCostumeData
{
    public Sprite Body;
    public Sprite Leg;
}
