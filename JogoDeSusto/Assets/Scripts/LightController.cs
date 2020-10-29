using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Material ligthOn = null, lightOff = null;
    [SerializeField] private bool isOn = false;
    private Light lightEffect;
    private MeshRenderer meshRenderer;
    private Material[] matArray;
    private void Start() {
        
        lightEffect = GetComponent<Light>();
        meshRenderer = GetComponent<MeshRenderer>();
        matArray = meshRenderer.materials;
        isOn = !isOn;
        Turn();
    }

    public void Turn(){
        isOn = !isOn;
        lightEffect.enabled = isOn;
        if(isOn) matArray[1] = ligthOn;
        else matArray[1] = lightOff;
        meshRenderer.materials = matArray;
    }

    public void Flicker(){
        if(isOn) StartCoroutine(FlickerCo());
    }
    private IEnumerator FlickerCo(){
        float originalLum = lightEffect.intensity;
        float brightness = originalLum;
        for(int i = 0; i < 5; i++){

            lightEffect.intensity = Random.Range(lightEffect.intensity/1.25f, lightEffect.intensity/4.75f);
            matArray[1] = lightOff;
            meshRenderer.materials = matArray;
            yield return new WaitForSeconds(Random.Range(0.1f,0.5f));

            lightEffect.intensity = Random.Range(lightEffect.intensity*1.25f, lightEffect.intensity*2f);
            matArray[1] = ligthOn;
            meshRenderer.materials = matArray;
            yield return new WaitForSeconds(Random.Range(0.1f,0.5f));

        }
        lightEffect.intensity = originalLum;
    }

}
