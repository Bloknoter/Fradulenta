using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private const float DELTA_MOVEMENT_TIME = 0.01f;

    [SerializeField]
    private Transform LeftGate;

    [SerializeField]
    private Transform RightGate;

    [SerializeField]
    [Min(0)]
    private float ShiftDistance;

    [SerializeField]
    private float ShiftingTime;

    [SerializeField]
    [Min(0)]
    private float WaitingTime;

    private enum GateStateEnum { Opening = 1, Closing = -1}

    private GateStateEnum gateState = GateStateEnum.Opening;

    void Start()
    {
        
    }

    private bool wasShifting;

    void Update()
    {
        if(!wasShifting)
        {
            wasShifting = true;
            StartCoroutine(Shifting());
        }
    }

    private IEnumerator Shifting()
    {
        int iteractionCount = (int)(ShiftingTime / DELTA_MOVEMENT_TIME);
        float speed = ShiftDistance / ShiftingTime * DELTA_MOVEMENT_TIME;
        int direction = (int)gateState;
        
        for (int i = 0; i < iteractionCount; i++)
        {
            LeftGate.Translate(new Vector2(-direction * speed, 0));
            RightGate.Translate(new Vector2(direction * speed, 0));
            yield return new WaitForSeconds(DELTA_MOVEMENT_TIME);
        }
        yield return new WaitForSeconds(WaitingTime);
        gateState = (GateStateEnum)((int)gateState * -1);
        wasShifting = false;
    }
}
