using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Plane _plane;

    private int _collisionDamage;
    private float _defaultSpeed;
    private CollisionTriggerHandler _collisionHandler;
    private GameObject _planePrefab;
    private Health _health;

    public int CollisionDamage => _collisionDamage;

    private void Awake()
    {
        Quaternion prefabRotation = _plane.PrefabPlane.transform.rotation;
        _planePrefab = Instantiate(_plane.PrefabPlane, transform.position, prefabRotation, transform);
        _health = gameObject.AddComponent<Health>();
        _health.Init(_plane.MinHealth, _plane.MaxHealth, _planePrefab.GetComponent<Collider2D>());
        _defaultSpeed = _plane.DefaultSpeed;
        _collisionDamage = _plane.CollisionDamage;
        _collisionHandler = _planePrefab.GetComponent<CollisionTriggerHandler>();
        _collisionHandler.OnCollisionEvent += ProcessCollision;
    }

    private void ProcessCollision(GameObject collidedObject, Collider2D collision)
    {
        if (collidedObject.TryGetComponent(out Player player))
        {
            _health.DecreaseHealth(player.CollisionDamage);
        }
        else if (collidedObject.TryGetComponent(out Bullet bullet))
        {
            _health.DecreaseHealth(bullet.CollisionDamage);
        }
    }

    private void Update()
    {
        transform.Translate(-_defaultSpeed * Time.deltaTime, 0, 0);
    }    
}
