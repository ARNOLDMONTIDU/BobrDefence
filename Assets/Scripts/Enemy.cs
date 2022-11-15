using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private List<GameObject> _wayPoints = new List<GameObject>();

    [SerializeField] private float _speed;
    private int _wayPointIndex = 0;

    public GameObject _wayPointParent;

    private void Start()
    {
        GetWayPoints();
    }

    private void GetWayPoints()
    {
        for (int i = 0; i < _wayPointParent.transform.childCount; i++)
        {
            _wayPoints.Add(_wayPointParent.transform.GetChild(i).gameObject);
        }
    }


    private void Update()
    {
        Move();
    }
    //123123123

    private void Move()
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
}
