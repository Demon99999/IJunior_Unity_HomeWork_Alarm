using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction<bool> Interacted;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Thief>(out Thief thief))
        {
            Interacted?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Thief>(out Thief thief))
        {
            Interacted?.Invoke(false);
        }
    }
}
