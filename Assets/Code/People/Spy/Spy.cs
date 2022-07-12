using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spy : Civil, IArrestable
{
    public bool HasLeftLocation { get; private set; }

    [SerializeField]
    private AbilityEngine.AbilityUse abilityUse;

    void Start()
    {
        mytransform.position = SpaceData.GetRandomPoint();
    }

    protected override void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            abilityUse.Use();
        }
    }

    private void FixedUpdate()
    {
        if (CurrentCivilState != state.Bearrested)
        {
            Vector2 move = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                move = new Vector2(move.x, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                move = new Vector2(move.x, -1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                move = new Vector2(-1, move.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                move = new Vector2(1, move.y);
            }
            if (move.x != 0 && move.y != 0)
            {
                float axis = 1 / Mathf.Sqrt(2);
                move = new Vector2(axis * move.x, axis * move.y);
            }
            movement.SetMovement(move);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CurrentCivilState != state.Bearrested)
        {
            C4Place place = collision.gameObject.GetComponent<C4Place>();
            if (place != null)
            {
                place.StartPutting();
            }
            if(collision.gameObject.tag == "Exit")
            {
                HasLeftLocation = true;
            }
        }       
    }
}
