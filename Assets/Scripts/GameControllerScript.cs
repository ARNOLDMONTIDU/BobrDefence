using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public float range, CoolDown, CurrentCoolDown = 0;
    public Sprite Spr;

    public Tower(float range, float coolDown, string path)
    {
        this.range = range;
        CoolDown = coolDown;
        Spr = Resources.Load<Sprite>(path);
    }

}

public class TowerProjectile
{
    public float speed;
    public int damage;
    public Sprite Spr;

    public TowerProjectile(float speed, int dmg, string path)
    {
        this.speed = speed;
        damage = dmg;
        Spr = Resources.Load<Sprite>(path);
    }
}

public enum TowerType
{ 
    FIRST_TOWER,
    SECOND_TOWER
}


public class GameControllerScript : MonoBehaviour
{
    public List<Tower> AllTowers = new List<Tower>();
    public List<TowerProjectile> AllProjectiles  = new List<TowerProjectile>();

    private void Awake()
    {
        AllTowers.Add(new Tower(2,.3f, "TowerSprites/FastTower"));
        AllTowers.Add(new Tower(5, 1, "TowerSprites/SlowTower"));

        AllProjectiles.Add(new TowerProjectile(7, 10, "ProjectilesSprites/FastProjectile"));
        AllProjectiles.Add(new TowerProjectile(3, 15, "ProjectilesSprites/SlowProjectile"));
    }
}
