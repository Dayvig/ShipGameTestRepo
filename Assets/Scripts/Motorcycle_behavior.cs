using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class Motorcycle_behavior : MonoBehaviour
{
    Model_Player playerModel;
    Controller_Effects effects;
    Controller_MotorcycleBullets bullets;
    public ParticleSystem ps;
    public float rate = 360;
    private float hitPoints;
    private float shootInterval;

    private float shootTimer;
    private MotorcycleEnemy values;
    private Vector3 toFireAt;
    public Vector3 nextWaypoint;
    public List<Vector3> Waypoints = new List<Vector3>();
    public int behaviourState;
    public bool isLeft;

    private void Start()
    {
        playerModel = GameObject.Find("Model").GetComponent<Model_Player>();
        effects = GameObject.Find("Controller").GetComponent<Controller_Effects>();
        bullets = GameObject.Find("Controller").GetComponent<Controller_MotorcycleBullets>();
        values = GameObject.Find("Model").GetComponent<MotorcycleEnemy>();
        hitPoints = values.hp;
        shootInterval = values.fireRate;
        shootTimer = Random.Range(0, shootInterval);
    }

    void Update()
    {
        MovementUpdate();
        if (!playerModel.shieldActive)
        {
            shootTimer += Time.deltaTime;
        }
        
        if (shootTimer >= shootInterval)
        {
            shootTimer -= shootInterval;
            toFireAt = new Vector3(
                (float) Math.Sin(values.bulletAngles[0] * Mathf.Deg2Rad),
                0,
                (float) Math.Cos(values.bulletAngles[0] * Mathf.Deg2Rad)
            );
            if (!isLeft)
            {
                toFireAt.x *= -1;
                Debug.Log(toFireAt);
            }
            bullets.FireBullet(transform.position, toFireAt);
        }

        transform.Rotate(Vector3.up * Time.deltaTime * rate);

        var around = Physics.OverlapSphere(transform.position, 1);
        foreach (Collider c in around)
        {
            if (c.gameObject.tag == "PlayerBullet")
            {
                c.gameObject.transform.position += Vector3.forward * 1000;
                hitPoints -= playerModel.damageCurrent;
                ps.Emit(40);
            }
        }

        if (hitPoints <= 0)
        {
            KillThisEnemy();
        }
    }
    
    public void MovementUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, values.moveSpeed * Time.deltaTime);
    }
    
    public void KillThisEnemy()
    {
        effects.MakeExplosion(transform.position);
        gameObject.SetActive(false);
    }
}