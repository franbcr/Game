using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBullet : Bullet
{
    private int LightningArmorDamage = 5;
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        PlayerStats.elementalArmor -= LightningArmorDamage;
    }
}
