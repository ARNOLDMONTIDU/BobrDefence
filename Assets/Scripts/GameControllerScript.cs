using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public string Name;
    public int type, Price;
    public float range, CoolDown, CurrentCoolDown = 0;
    public Sprite Spr;

    public Tower(string Name, int type, float range, float coolDown, int Price, string path)
    {
        this.Name = Name;
        this.type = type;
        this.range = range; 
        CoolDown = coolDown;
        this.Price = Price;
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
    public Sprite Spr;

    public Enemy(float health, float speed, string sprPath)
    {
        Health = health;
        StartSpeed= Speed = speed;

        Spr = Resources.Load<Sprite>(sprPath);
    }

    public Enemy(Enemy other)
    {
        Health = other.Health;
        StartSpeed = Speed = other.StartSpeed;
        Spr = other.Spr;
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
    public List<Enemy> AllEnemies = new List<Enemy>();

    private void Awake()
    {
        //name, range, cooldown, Price, path
        AllTowers.Add(new Tower("FastTower", 0, 2, 3f, 10, "TowerSprites/FastTower"));
        AllTowers.Add(new Tower("SlowTower", 1, 4, 1f, 20,"TowerSprites/SlowTower")); 
        AllTowers.Add(new Tower("OneMoreTower", 2, 3, 2f, 30,"TowerSprites/OneMoreTower"));
        //speed, damage, path
        AllProjectiles.Add(new TowerProjectile(7, 10, "ProjectilesSprites/FastProjectile"));
        AllProjectiles.Add(new TowerProjectile(3, 15, "ProjectilesSprites/SlowProjectile"));
        AllProjectiles.Add(new TowerProjectile(4, 8, "ProjectilesSprites/SlowProjectile"));

        AllEnemies.Add(new Enemy(60,2, "EnemySprites/SimpleEnemy"));
        AllEnemies.Add(new Enemy(30, 4, "EnemySprites/FastEnemy"));
        AllEnemies.Add(new Enemy(100, 1.5f, "EnemySprites/HeavyEnemy"));
    }
}
