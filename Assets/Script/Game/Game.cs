using UnityEngine;

[CreateAssetMenu(fileName = "new game", menuName = "Game", order = 51)]
public class GameData : ScriptableObject
{
    [SerializeField] private Background[] _backgrounds;
    [SerializeField] private Plane[] _enemyPlanes;
    [SerializeField] private Plane[] _playerPlanes;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private int _itemsCount;
}
