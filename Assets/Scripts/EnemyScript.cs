using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private List<GameObject> _wayPoints = new List<GameObject>();

    [SerializeField] public float _speed;
    float startSpeed = 2;
    private int _wayPointIndex = 0;
    [SerializeField] private int _health = 30;

    public GameObject _wayPointParent;


    private void Start()
    {
        GetWayPoints();
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

        transform.Translate(directionMove.normalized * Time.deltaTime * _speed);

        if (Vector3.Distance(transform.position, _wayPoints[_wayPointIndex].transform.position) < 0.01f)
        {
            if (_wayPointIndex < _wayPoints.Count - 1)
            {
                _wayPointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void StartSlow(float duration, float slowValue)
    {
        _speed = startSpeed;
        StopCoroutine("GetSlow");
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        _speed -= slowValue;
        yield return new WaitForSeconds(duration);
        _speed = startSpeed;
    }

}
