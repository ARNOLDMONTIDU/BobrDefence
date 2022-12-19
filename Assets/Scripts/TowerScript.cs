using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _CurrentCoolDown, _CoolDown;
    [SerializeField] private GameObject _projectile;


    private void Update()
    {
        if (CanShoot())
            FindTarget();

        if (_CurrentCoolDown > 0)
            _CurrentCoolDown -= Time.deltaTime;
    }

    private bool CanShoot()
    {
        if (_CurrentCoolDown <= 0)
            return true;
        return false;
    }

    private void FindTarget()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if (currentDistance < nearestEnemyDistance && currentDistance <= _range)
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

    private void Shoot(Transform enemy)
    {
        _CurrentCoolDown = _CoolDown;

        GameObject projectile = Instantiate(_projectile);
        projectile.transform.position = transform.position;
        projectile.GetComponent<ProjectileScript>().SetTarget(enemy);
    }
}
