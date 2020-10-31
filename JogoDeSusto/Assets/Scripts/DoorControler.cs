using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    private Animator anim;
    private bool isOpened, inRange = false;
    
    [SerializeField] private Signal DoorClosingSignal = null;
    [SerializeField] private float minTimeDoorClosing = 0f, maxTimeDoorClosing = 0f;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        if(isOpened && inRange){
            isOpened = true;
            anim.SetTrigger("open");
            StartCoroutine(closeCo());
        }  
    }

    private void Close()
    {
        if(!isOpened){
            isOpened = false;
        }
    }

    private IEnumerator closeCo()
    {
        yield return new WaitForSeconds( Random.Range( minTimeDoorClosing, maxTimeDoorClosing ));
        Close();
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
