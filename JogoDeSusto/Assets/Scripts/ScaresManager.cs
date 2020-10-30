using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaresManager : MonoBehaviour
{
    [Header("LightFlick")]
    [SerializeField] private Signal LightFlickSignal = null;
    [SerializeField] private float minTimeLightFlick = 0f;
    [SerializeField] private float maxTimeLightFlick = 0f;

    private void Start() {
        StartCoroutine(FlickerScare());
    }
    private IEnumerator FlickerScare(){
        yield return new WaitForSeconds(Random.Range(minTimeLightFlick,maxTimeLightFlick));
        LightFlickSignal.Raise();
        StartCoroutine(FlickerScare());
    }
}
