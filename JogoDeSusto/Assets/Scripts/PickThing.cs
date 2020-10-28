using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickThing : MonoBehaviour
{
   [SerializeField] private GlobalBool hasItem = null;
   [SerializeField] private Transform player = null;
    private bool inRange = false;

    public void Submmited()
    {

        if(inRange && !hasItem.Value){
            hasItem.Value = true;
            this.GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(player);
            transform.localPosition = new Vector3(0f,0f,0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) inRange = false;
    }
}
