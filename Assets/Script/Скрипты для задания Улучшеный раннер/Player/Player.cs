using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerControls))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Weapon))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _collisionBurst;
    [SerializeField] private GameObject _crashBurst;

    public UnityAction PlayerDied;
    private Health _health;
    private Weapon _weapon;
    private PlayerControls _playerControls;
    private PlayerMover _playerMover;
    private int _collisionDamage;
    private CollisionTriggerHandler _collisionHandler;
    private GameObject _planePrefab;
    private Bullet _bullet;

    public int CollisionDamage => _collisionDamage;

    private void Awake()
    {       
        _health = GetComponent<Health>();
        _weapon = GetComponent<Weapon>();
        _playerControls = GetComponent<PlayerControls>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnDisable()
    {
        _collisionHandler.OnCollisionEvent -= ProcessCollision;
    }

    private void OnDestroy()
    {
        PlayerDied?.Invoke();
    }

    public void Init(Plane plane)
    {
        Quaternion prefabRotation = plane.PrefabPlane.transform.rotation;
        _planePrefab = Instantiate(plane.PrefabPlane, transform.position, prefabRotation, transform);
        _bullet = plane.Bullet.GetComponent<Bullet>();
        _weapon.Init(plane.MaxAmmo, _bullet);
        _health.Init(plane.MinHealth, plane.MaxHealth, _planePrefab.GetComponent<Collider2D>(), _crashBurst);
        _playerControls.Init(_playerMover, _weapon);
        _collisionDamage = plane.CollisionDamage;
        _collisionHandler = _planePrefab.GetComponent<CollisionTriggerHandler>();
        _collisionHandler.OnCollisionEvent += ProcessCollision;
    }
    
    private void ProcessCollision(GameObject collidedObject, Collider2D collision)
    {
        if (collidedObject.TryGetComponent(out Enemy enemy))
        {
            Vector3 impactPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z - 0.1f);
            Instantiate(_collisionBurst, impactPosition, transform.rotation);
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
