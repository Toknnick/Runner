using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnsPoints;

    private int _numberOfSpawnPoint;
    private float _timeForSpawn = 1.1f;
    private float _nowTime;

    private void Start()
    {
        Initialize(_prefab);
    }


    private void Update()
    {
        _nowTime += Time.deltaTime;

        if (_timeForSpawn <= _nowTime)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _nowTime = 0;
                _numberOfSpawnPoint = Random.Range(0, _spawnsPoints.Length);
                enemy.SetActive(true);
                enemy.transform.position = _spawnsPoints[_numberOfSpawnPoint].position;
            }
        }
    }
}
