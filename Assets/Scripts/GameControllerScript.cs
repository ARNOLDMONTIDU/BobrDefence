using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public float range, CoolDown, CurrentCoolDown = 0;

    Tower(float range, float coolDown)
    {
        this.range = range;
        CoolDown = coolDown;

    }

}

public class TowerProjectile
{ 
    
}

public enum TowerType
{ 
    FIRST_TOWER,
    SECOND_TOWER
}


public class GameControllerScript : MonoBehaviour
{
    
}
