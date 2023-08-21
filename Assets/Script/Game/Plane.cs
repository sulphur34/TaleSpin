using UnityEngine;

[CreateAssetMenu(fileName = "new plane", menuName = "Plane", order = 51)]
public class Plane : ScriptableObject
{
    [SerializeField] private GameObject _prefabPlane;
    [SerializeField] private int _collisionDamage;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private int _defaultSpeed;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private GameObject _bulletPrefab;

    public GameObject PrefabPlane => _prefabPlane;
    public GameObject Bullet => _bulletPrefab;
    public int CollisionDamage => _collisionDamage;
    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int DefaultSpeed => _defaultSpeed;
    public int MaxAmmo => _maxAmmo;
}
