using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaresManager : MonoBehaviour
{
    [Header("LightFlick")]
    [SerializeField] private Signal LightFlickSignal = null;
    [SerializeField] private float minTimeLightFlick = 0f;
    [SerializeField] private float maxTimeLightFlick = 0f;

    [Header("FlyingBook")]
    [SerializeField] private Signal FlyingBookSignal = null;
    [SerializeField] private float minTimeFlyingBook = 0f;
    [SerializeField] private float maxTimeFlyingBook = 0f;

    private void Start() {
        StartCoroutine(Scare(LightFlickSignal, minTimeLightFlick, maxTimeLightFlick));
        StartCoroutine(Scare(FlyingBookSignal, minTimeFlyingBook, maxTimeFlyingBook));
    }

    private IEnumerator Scare(Signal signal, float minTime, float maxTime){
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        signal.Raise();
        StartCoroutine(Scare(signal, minTime, maxTime));
    }

}
