using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Catcher : MonoBehaviour
{
    public Transform enemy1;
    public Transform enemy2;
    void Update()
    {
        if (enemy1.transform.position.z == -20) 
        {
            Destroy(gameObject);
        }
        if (enemy2.transform.position.z == -20)
        {
            Destroy(gameObject);
        }
    }
}
