using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerControls))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Plane _plane;

    private Health _health;
    private Weapon _weapon;
    private int _collisionDamage;
    private CollisionTriggerHandler _collisionHandler;
    private GameObject _planePrefab;
    private Bullet _bullet;

    public int CollisionDamage => _collisionDamage;

    private void Awake()
    {        
        Init();
    }

    private void OnDisable()
    {
        _collisionHandler.OnCollisionEvent -= ProcessCollision;
    }

    private void Init()
    {
        Quaternion prefabRotation = _plane.PrefabPlane.transform.rotation;
        _planePrefab = Instantiate(_plane.PrefabPlane, transform.position, prefabRotation, transform);
        _bullet = _plane.Bullet.GetComponent<Bullet>();
        _weapon = gameObject.AddComponent<Weapon>();
        _weapon.Init(_plane.MaxAmmo, _bullet);
        _health = gameObject.AddComponent<Health>();
        _health.Init(_plane.MinHealth, _plane.MaxHealth, _planePrefab.GetComponent<Collider2D>());
        GetComponent<PlayerControls>().Init(GetComponent<PlayerMover>(), _weapon);
        _collisionDamage = _plane.CollisionDamage;
        _collisionHandler = _planePrefab.GetComponent<CollisionTriggerHandler>();
        _collisionHandler.OnCollisionEvent += ProcessCollision;
    }
    
    private void ProcessCollision(GameObject collidedObject, Collider2D collision)
    {
        if (collidedObject.TryGetComponent(out Enemy enemy))
        {
            _health.DecreaseHealth(enemy.CollisionDamage);
        }
        else if (collidedObject.TryGetComponent(out HealthIncreaser healthIncreaser))
        {
            _health.IncreaseHealth(healthIncreaser);
        }
        else if (collidedObject.TryGetComponent(out AmmoIncreaser ammoIncreaser))
        {
            GetComponent<Weapon>().AddAmmo(ammoIncreaser);
        }
    }
}
