using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    
    private Transform target;
    public TowerProjectile selfProjectile;
    public Tower selfTower;
    GameControllerScript gcs;

    private void Start()
    {
        

        gcs = FindObjectOfType<GameControllerScript>();

        selfProjectile = gcs.AllProjectiles[selfTower.type];
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
                Hit();
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

    void Hit()
    {
        switch (selfTower.type)
        {
            case (int)TowerType.FIRST_TOWER:
                
                target.GetComponent<EnemyScript>().TakeDamage(selfProjectile.damage);
                break;
            case (int)TowerType.SECOND_TOWER:
                target.GetComponent<EnemyScript>().AOEDamage(2,selfProjectile.damage);
                target.GetComponent<EnemyScript>().TakeDamage(selfProjectile.damage);
                break;
            case (int)TowerType.THIRTH_TOWER:
                target.GetComponent<EnemyScript>().StartSlow(3, 1);
                target.GetComponent<EnemyScript>().TakeDamage(selfProjectile.damage);
                break;
        }
        Destroy(gameObject);
    }
}
