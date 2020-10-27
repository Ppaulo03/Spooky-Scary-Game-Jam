using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Material ligthOn = null, LightOff = null;
    [SerializeField] private GameObject lightEffect = null;
    [SerializeField] private bool isOn = false;

    public void Turn(){
        isOn = !isOn;
        lightEffect.SetActive(isOn);
        if(isOn) GetComponent<MeshRenderer> ().material = ligthOn;
        else GetComponent<MeshRenderer> ().material = LightOff;
    }
}
