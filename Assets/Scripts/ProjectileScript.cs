using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    
    private Transform target;
    public TowerProjectile selfProjectile;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = selfProjectile.Spr;
    }

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
                target.GetComponent<EnemyScript>().TakeDamage(selfProjectile.damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 direction = target.position - transform.position;
                transform.Translate(direction.normalized * Time.deltaTime * selfProjectile.speed);
            }
        }
        else
            Destroy(gameObject);
    }


}
