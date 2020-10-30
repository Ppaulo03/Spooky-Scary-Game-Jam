using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torneira : MonoBehaviour
{
    [SerializeField] private Signal Action = null, UIcommand = null;
    private bool isPressing = false;
    private float correct;
    private Vector3 mousePosition;
    public void pressControl(bool state, float correction, Vector3 mousPos){
        mousePosition = mousPos;
        correct = correction;
        isPressing = state;
    }
    void Update()
    {
        if(isPressing){    
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = mousePosition - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            angle += correct; 
            if(angle <= 0 ) angle += 360;

            if(angle < transform.eulerAngles.z && (transform.eulerAngles.z - angle) < 90f)
                transform.rotation = Quaternion.Euler(0,0,angle);
            else if(transform.eulerAngles.z < 5){
                UIcommand.Raise();
                Action.Raise();
            }
            if(!Input.GetMouseButton(0)) isPressing = false;
        }
    }
}
