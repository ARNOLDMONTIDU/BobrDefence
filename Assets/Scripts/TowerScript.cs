using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    [SerializeField] private GameObject _projectile;
    Tower selfTower;
    public TowerType selfType;
    GameControllerScript gcs;


    private void Start()
    {
        gcs = FindObjectOfType<GameControllerScript>();

        selfTower = gcs.AllTowers[(int)selfType];

        GetComponent<SpriteRenderer>().sprite = selfTower.Spr;

        InvokeRepeating("FindTarget", 0 , .1f);

    }

    private void Update()
    {


        if (selfTower.CurrentCoolDown > 0)
            selfTower.CurrentCoolDown -= Time.deltaTime;
    }

    private bool CanShoot()
    {
        if (selfTower.CurrentCoolDown <= 0)
            return true;
        return false;
    }

    private void FindTarget()
    {
        if (CanShoot())
        {



            Transform nearestEnemy = null;
            float nearestEnemyDistance = Mathf.Infinity;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (currentDistance < nearestEnemyDistance && currentDistance <= selfTower.range)
                {
                    nearestEnemy = enemy.transform;
                    nearestEnemyDistance = currentDistance;
                }

            }

            if (nearestEnemy != null)
            {
                Shoot(nearestEnemy);
            }

        }
    }

    private void Shoot(Transform enemy)
    {
        selfTower.CurrentCoolDown = selfTower.CoolDown;

        GameObject projectile = Instantiate(_projectile);
        projectile.GetComponent<ProjectileScript>().selfTower = selfTower;
        projectile.transform.position = transform.position;
        projectile.GetComponent<ProjectileScript>().SetTarget(enemy);
    }
}
