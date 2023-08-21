using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoIncreaser : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;
    [SerializeField] private float _speed;

    private CollisionTriggerHandler _collisionHandler;

    public int AmmoAmount => _ammoAmount;

    private void Awake()
    {
        _collisionHandler = GetComponentInChildren<CollisionTriggerHandler>();
        _collisionHandler.OnCollisionEvent += ProcessCollision;
    }

    private void ProcessCollision(GameObject collidedObject, Collider2D collision)
    {
        if (collidedObject.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }
}
