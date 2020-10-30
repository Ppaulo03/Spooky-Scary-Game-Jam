using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBook : MonoBehaviour
{
    [SerializeField] private Transform player = null;
    [SerializeField] private float force = 20f;
    [SerializeField] private Vector3 correction = Vector3.zero; 
    [SerializeField] private bool randomize = false; 

    public void fly(){
        float actForce = 0f;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        if(randomize){
            correction = new Vector3(Random.Range(0f,7f), Random.Range(-3f,0f), Random.Range(0f,7f));
            actForce = Random.Range(force - (force/10) ,force + (force/10));
        }
        else actForce = force;
        Vector3 direction = (player.position - (transform.position + correction)).normalized;
        rb.AddForce(direction*actForce, ForceMode.Impulse);

    }
        
}
