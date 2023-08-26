using UnityEngine;
using IJunior.TypedScenes;
using System.Collections;

public class GameController : MonoBehaviour, ISceneLoadHandler<(Plane, Background, Difficulty)>
{  
    [SerializeField] private Plane[] _enemyPlanes;
    [SerializeField] private GameObject[] _itemPrefabs;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private GameObject _winZone;

    private Coroutine _spawnCoroutine;
    private System.Random _random;
    private Player _player;
    private Background _background;
    private Plane _playerPlane;
    private Difficulty _difficulty;
    private int _enemiesSpawnedCount;

    public int EnemiesCount => _difficulty.EnemiesCount;
    public int EnemiesSpawnedCount => _enemiesSpawnedCount;
    public int PlayerHealth => _player.GetComponent<Health>().CurrentHealth;
    public int PlayerAmmo => _player.GetComponent<Weapon>().CurrentAmmo;
      
    public void Start()
    {
        _random = new System.Random();
        SetBackground();
        SetPlayer();
        _player.PlayerDied += EnableLoosePanel;
        _winZone.GetComponent<WinZone>().ZoneEntered += EnableWinPanel;
        _spawnCoroutine = StartCoroutine(SpawnEnemies());        
    }

    public void OnSceneLoaded((Plane, Background, Difficulty) argument)
    {
        _playerPlane = argument.Item1;
        _background = argument.Item2;
        _difficulty = argument.Item3;
    }

    public void LoadMainMenu()
    {
        MainMenu.Load();
    }

    private void EnableLoosePanel()
    {
        StopCoroutine(_spawnCoroutine);
        _loosePanel.SetActive(true);
        Unsubscribe();
    }

    private void EnableWinPanel()
    {
        StopCoroutine(_spawnCoroutine);
        _winPanel.SetActive(true);
        _player.gameObject.SetActive(false);
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        _player.PlayerDied -= EnableLoosePanel;
        _winZone.GetComponent<WinZone>().ZoneEntered -= EnableWinPanel;
    }

    private void SetBackground()
    {
        Instantiate(_background.BackgroundPrefab)
            .GetComponent<Canvas>()
            .worldCamera = _camera;
    }

    private void SetPlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
        _player.Init(_playerPlane);
        PlayerMover mover = _player.GetComponent<PlayerMover>();
        mover.SetCamera(_camera);
    }

    private IEnumerator SpawnEnemies()
    {
        int maxChanceValue = 101;

        for (int i = 0; i < _difficulty.EnemiesCount; i++)
        {
            _enemiesSpawnedCount = i + 1;
            int itemChance = _random.Next(maxChanceValue);

            if (itemChance <= _difficulty.IncreasersChance)
                SpawnRandomItem();
            else
                SpawnRandomEnemy();
            
            yield return new WaitForSecondsRealtime(_difficulty.SpawnDelay);
        }

        _winZone.gameObject.SetActive(true);
    }

    private void SpawnRandomEnemy()
    {
        int enemyIndex = _random.Next(_enemyPlanes.Length);
        Transform spawnPoint = _enemySpawnPoints[_random.Next(_enemySpawnPoints.Length)];
        Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.Init(_enemyPlanes[enemyIndex]);
    }

    private void SpawnRandomItem()
    {
        int itemIndex = _random.Next(_itemPrefabs.Length);
        Transform spawnPoint = _enemySpawnPoints[_random.Next(_enemySpawnPoints.Length)];
        Instantiate(_itemPrefabs[itemIndex], spawnPoint.position, Quaternion.identity);
    }
}
