using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private Transform mytransform;

    [SerializeField]
    private SpriteRenderer myrenderer;

    [SerializeField]
    private Color AllowedColor = Color.white;

    [SerializeField]
    private Color DisallowedColor;

    void Start()
    {
        
    }

    private bool wasDissappearing;

    void Update()
    {
        if(!wasDissappearing)
        {
            wasDissappearing = true;
            StartCoroutine(Dissapearing());
        }
    }

    public void SetState(bool allowed)
    {
        if(allowed)
        {
            myrenderer.color = new Color(AllowedColor.r, AllowedColor.g, AllowedColor.b);
        }
        else
        {
            myrenderer.color = new Color(DisallowedColor.r, DisallowedColor.g, DisallowedColor.b);
        }
    }

    private IEnumerator Dissapearing()
    {
        for(int i = 0; i < 40;i++)
        {
            Color newcolor = myrenderer.color;
            newcolor.a -= 0.025f;
            myrenderer.color = newcolor;
            mytransform.localScale = new Vector2(mytransform.localScale.x + 0.025f, mytransform.localScale.y + 0.025f);
            yield return new WaitForSeconds(0f);
        }
        Destroy(gameObject);
    }
}
