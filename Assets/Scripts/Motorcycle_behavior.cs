using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class Motorcycle_behavior : Base_Enemy_Behavior
{
    private float shootTimer;
    private MotorcycleEnemy values;
    public bool isLeft;
    
    public override void MovementUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, values.moveSpeed * Time.deltaTime);
    }

    public override void SetupEnemy()
    {
        shootTimer = Random.Range(0, shootInterval);
        values = GameObject.Find("Model").GetComponent<MotorcycleEnemy>();
    }

    public override bool Immune()
    {
        return false;
    }

    public override bool canShoot()
    {
        if (inScreen())
        {
            return true;
        }

        return false;
    }

    public override void UpdateVisuals()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rate);
    }

    public override void FiringPattern()
    {
        bullets.FireBullet(transform.position, (playerModel.ship.transform.position - transform.position).normalized);
    }
}