using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _movementRight = 1;
    private int _movementLeft = -1;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(_movementLeft);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(_movementRight);
        }
    }

    private void Move(int direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction,0,0);
    }
}
