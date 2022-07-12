using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MovingEngine;

public class Bot : Civil
{

    protected override void OnUpdate()
    {
        if (CurrentCivilState != state.Bearrested)
        {
            if (!movement.IsMoving() && CurrentCivilState != state.Waiting)
            {
                CurrentCivilState = (state)Random.Range(1, 3);
                if (CurrentCivilState == state.Moving)
                {
                    StartCoroutine(Walking());
                }
                else if (CurrentCivilState == state.Waiting)
                {
                    StartCoroutine(Waiting());
                }
            }
            if (CurrentCivilState == state.Start)
            {
                CurrentCivilState = state.Waiting;
                StartCoroutine(Waiting());
            }
        }
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(Random.Range(3, 6));
        CurrentCivilState = state.Moving;
        StartCoroutine(Walking());
    }

    private IEnumerator Walking()
    {
        movement.SetMovement(GetRandomMovingVector());
        yield return new WaitForSeconds(2f);
        movement.SetMovement(GetRandomMovingVector());
        yield return new WaitForSeconds(2f);
        movement.StopMoving();
    }

    private Vector2 GetRandomMovingVector()
    {
        Vector2 result = new Vector2(Random.Range(-1, 2), 0);
        if(result.x == 0)
        {
            result = new Vector2(result.x, Random.Range(0, 2) * 2 - 1);
        }
        else
        {
            result = new Vector2(result.x, Random.Range(-1, 2));
        }
        if(result.x != 0 && result.y != 0)
        {
            float axis = 1 / Mathf.Sqrt(2);
            result = new Vector2(axis * result.x, axis * result.y);
        }
        return result;
    }
        
}
