using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private List<GameObject> _wayPoints = new List<GameObject>();

    public Enemy selfEnemy;

    //[SerializeField] public float _speed;
    //float startSpeed = 2;
    //[SerializeField] private int _health = 30;
    private int _wayPointIndex = 0;


    public GameObject _wayPointParent;


    private void Start()
    {
        GetWayPoints();

        GetComponent<SpriteRenderer>().sprite = selfEnemy.Spr;
    }

    private void Update()
    {

        MoveEnemy();
        
    }

    private void GetWayPoints()
    {
        for (int i = 0; i < _wayPointParent.transform.childCount; i++)
        {
            _wayPoints.Add(_wayPointParent.transform.GetChild(i).gameObject);
        }
    }

    private void MoveEnemy()
    {
        Vector3 directionMove = _wayPoints[_wayPointIndex].transform.position - transform.position;

        transform.Translate(directionMove.normalized * Time.deltaTime * selfEnemy.Speed);

        if (Vector3.Distance(transform.position, _wayPoints[_wayPointIndex].transform.position) < 0.01f)
        {
            if (_wayPointIndex < _wayPoints.Count - 1)
            {
                _wayPointIndex++;
            }
            else
            {
                GameManager.Instance.MinusLive();
                FindObjectOfType<EnemySpawner>()._countOfDeadEnemies++;
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        selfEnemy.Health -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (selfEnemy.Health <= 0)
        {
            GameManager.Instance.GameMoney += 15;
            FindObjectOfType<EnemySpawner>()._countOfDeadEnemies++;
            Destroy(gameObject);
        }
    }

    public void StartSlow(float duration, float slowValue)
    {
        selfEnemy.Speed = selfEnemy.StartSpeed;
        StopCoroutine("GetSlow");
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        selfEnemy.Speed -= slowValue;
        yield return new WaitForSeconds(duration);
        selfEnemy.Speed = selfEnemy.StartSpeed;
    }


    public void AOEDamage(float range, int damage)
    {
        List<EnemyScript> enemies = new List<EnemyScript>(); 

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector2.Distance(transform.position, go.transform.position) <= range)
            {
                enemies.Add(go.GetComponent<EnemyScript>());
            }
        }

        foreach (EnemyScript es in enemies)
        {
            es.TakeDamage(damage);
        }
    }
}
