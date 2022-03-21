using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class Gas_Canister : MonoBehaviour
{
    public Controller_Fuel controllerFuel;
    // Start is called before the first frame update
    void Start()
    {
        controllerFuel = GameObject.Find("Controller").GetComponent<Controller_Fuel>();
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.position -= new Vector3(0,0,0.01f);
       if (transform.position.z <= -11)
       {
           Destroy(this.gameObject);
       }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        controllerFuel.SetFuel(controllerFuel.currentFuel+5);
        Destroy(this.gameObject);
    }
}
