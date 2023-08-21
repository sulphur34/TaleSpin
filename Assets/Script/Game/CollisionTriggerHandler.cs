using UnityEngine;

public class CollisionTriggerHandler : MonoBehaviour
{
    public delegate void CollisionEventHandler(GameObject collidedObject, Collider2D collision);
    public event CollisionEventHandler OnCollisionEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollisionEvent?.Invoke(collision.transform.parent?.gameObject, collision);
    }
}