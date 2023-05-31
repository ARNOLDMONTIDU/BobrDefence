using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab, _wayPointParent;
    [SerializeField] private float _constTimeToSpawn;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private int _wavesCount;
    private int _numberOfWave = 0;
    [SerializeField] private Transform _enemiesParent;

    [SerializeField] private TextMeshProUGUI _textNumberOfWave;

    GameControllerScript gcs;

    private void Start()
    {
        gcs = FindObjectOfType<GameControllerScript>();
    }

    void Update()
    {
        if (_timeToSpawn <= 0 && _numberOfWave < _wavesCount)
        {
            StartCoroutine(SpawnEnemy(_numberOfWave + 1));
            _timeToSpawn = _constTimeToSpawn;
        }

        _timeToSpawn -= Time.deltaTime;

        _textNumberOfWave.text = _numberOfWave.ToString();
    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        _numberOfWave++;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject tempEnemy = Instantiate(_enemyPrefab);
            tempEnemy.transform.SetParent(gameObject.transform, false);

            

            tempEnemy.GetComponent<EnemyScript>()._wayPointParent = _wayPointParent;
            tempEnemy.GetComponent<EnemyScript>().selfEnemy = new Enemy(gcs.AllEnemies[Random.Range(0, gcs.AllEnemies.Count)]);
            

            yield return new WaitForSeconds(0.6f);
        }

        
    }
}
