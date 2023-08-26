using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinZone : MonoBehaviour
{
    public UnityAction ZoneEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.TryGetComponent<Player>(out Player player))
            ZoneEntered?.Invoke();
    }
}
