using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresPanel : MonoBehaviour
{
    [SerializeField] private Signal lightsOn = null, UIcommand = null;
    private int wiresConnected = 0;
    private int numWires = 5;
    private bool turned = false;

    public void connectWire(){
        if(!turned){
            wiresConnected ++;
            if(wiresConnected >= numWires){
                UIcommand.Raise();
                lightsOn.Raise();
                turned = true;
            }
        }
    }
    private void OnDisable() {
        wiresConnected = 0;
    }
}
