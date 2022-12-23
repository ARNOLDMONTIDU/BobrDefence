using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage = 10;

    private Transform target;

    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < .1f)
            {
                target.GetComponent<EnemyScript>().TakeDamage(_damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 direction = target.position - transform.position;
                transform.Translate(direction.normalized * Time.deltaTime * _speed);
            }
        }
        else
            Destroy(gameObject);
    }


}
