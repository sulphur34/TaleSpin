using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _burstOnCrash;

    private int _collisionDamage;
    private float _defaultSpeed;
    private CollisionTriggerHandler _collisionHandler;
    private GameObject _planePrefab;
    private Health _health;

    public int CollisionDamage => _collisionDamage;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (transform.position.x < -11f)
            Destroy(gameObject);

        transform.Translate(-_defaultSpeed * Time.deltaTime, 0, 0);
    }

    public void Init(Plane plane)
    {
        Quaternion prefabRotation = plane.PrefabPlane.transform.rotation;
        _planePrefab = Instantiate(plane.PrefabPlane, transform.position, prefabRotation, transform);
        _health.Init(plane.MinHealth, plane.MaxHealth, _planePrefab.GetComponent<Collider2D>(), _burstOnCrash);
        _defaultSpeed = plane.DefaultSpeed;
        _collisionDamage = plane.CollisionDamage;
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
}
