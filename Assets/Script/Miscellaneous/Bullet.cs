using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _burst;
    [SerializeField] private int _collisionDamage;

    private CollisionTriggerHandler _collisionHandler;

    public int CollisionDamage => _collisionDamage;

    private void Awake()
    {
        _collisionHandler = GetComponentInChildren<CollisionTriggerHandler>();
        _collisionHandler.OnCollisionEvent += ProcessCollision;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime,0, 0);
    }

    private void ProcessCollision(GameObject collidedObject, Collider2D collision)
    {
        if (collidedObject.TryGetComponent(out Enemy enemy) 
            && collidedObject.TryGetComponent(out Health health))
        {
            Vector3 impactPosition = collision.ClosestPoint(transform.position);
            impactPosition.Set(impactPosition.x, impactPosition.y, impactPosition.z - 0.1f);
            Instantiate(_burst, impactPosition, transform.rotation);            
            Destroy(gameObject);
        }
    }
}
