using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public int type;
    public float range, CoolDown, CurrentCoolDown = 0;
    public Sprite Spr;

    public Tower(int type,float range, float coolDown, string path)
    {
        this.type = type;
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

public class Enemy
{
    public float Health, Speed, StartSpeed;

    public Enemy(float health, float speed, string sprPath)
    {
        Health = health;
        StartSpeed= Speed = speed;
    }

}

public enum TowerType
{ 
    FIRST_TOWER,
    SECOND_TOWER,
    THIRTH_TOWER

}


public class GameControllerScript : MonoBehaviour
{
    public List<Tower> AllTowers = new List<Tower>();
    public List<TowerProjectile> AllProjectiles  = new List<TowerProjectile>();

    private void Awake()
    {
        //range, cooldown, path
        AllTowers.Add(new Tower(0, 2,.3f, "TowerSprites/FastTower"));
        AllTowers.Add(new Tower(1, 4, 1, "TowerSprites/SlowTower")); 
        AllTowers.Add(new Tower(2, 3, 2, "TowerSprites/OneMoreTower"));
        //speed, damage, path
        AllProjectiles.Add(new TowerProjectile(7, 10, "ProjectilesSprites/FastProjectile"));
        AllProjectiles.Add(new TowerProjectile(3, 15, "ProjectilesSprites/SlowProjectile"));
        AllProjectiles.Add(new TowerProjectile(4, 8, "ProjectilesSprites/SlowProjectile"));
    }
}
