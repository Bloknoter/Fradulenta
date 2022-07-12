using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4Place : MonoBehaviour
{
    public delegate void OnC4PlacedDelegate();

    public event OnC4PlacedDelegate OnC4PlacedEvent;

    [SerializeField]
    private GameObject C4Prefab;

    [SerializeField]
    private SpriteRenderer[] myrenderers;

    [SerializeField]
    [Min(0)]
    private float PuttingTime;

    public bool IsPutting { get; private set; }

    public void StartPutting()
    {
        StartCoroutine(PuttingC4());
    }

    private IEnumerator PuttingC4()
    {
        yield return new WaitForSeconds(PuttingTime);
        GameObject c4 = Instantiate(C4Prefab);
        c4.transform.position = transform.position;
        OnC4PlacedEvent?.Invoke();
        for (int i = 0; i < 100;i++)
        {
            for (int r = 0; r < myrenderers.Length; r++)
            {
                myrenderers[r].color = new Color(myrenderers[r].color.r, myrenderers[r].color.g, myrenderers[r].color.b, myrenderers[r].color.a - 0.005f);
            }
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
