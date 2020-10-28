using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    private bool activated = false;
    private void Update() {
        if(activated && Input.GetKeyDown(KeyCode.Space)) DisableUI();
    }

    public void EnableUi(){
        player.GetComponent<PlayerController>().enabled = false;
        MouseLook[] scripts = FindObjectsOfType(typeof(MouseLook)) as MouseLook[];
        foreach (MouseLook script in scripts) {
            script.enabled = false;
        };
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        activated = true;
    }

    public void DisableUI(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (Transform child in transform){
            if(child != transform) child.gameObject.SetActive(false);
        } 
        
        player.GetComponent<PlayerController>().enabled = true;
        
        MouseLook[] scripts = FindObjectsOfType(typeof(MouseLook)) as MouseLook[];
        foreach (MouseLook script in scripts) script.enabled = true;
        
        activated = false;
    }

}
