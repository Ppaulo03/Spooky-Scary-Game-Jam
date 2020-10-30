using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopInfinito : MonoBehaviour
{
    [SerializeField] private Transform teleport = null;
    [SerializeField] private Light lantern = null, aura = null;
    [SerializeField] private GlobalBool pass = null;
    [SerializeField] private bool entry = false;
    [SerializeField] private float chance = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(entry) pass.Value = true;
    
            else if(pass.Value){
                if(Random.Range(0,100) < chance) StartCoroutine(teleportCo(other));
                StartCoroutine(fade(aura));
                StartCoroutine(fade(lantern)); 
                pass.Value = false;
            }

            else pass.Value = false;
        }
    }

    private IEnumerator fade(Light lume){
        float brightnessTotal = lume.intensity;
        float brightness = brightnessTotal;
        for(int i=0; i < 5; i++){
            brightness -= brightnessTotal/5f;
            lume.intensity = brightness;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        for(int i=0; i < 5; i++){
            brightness += brightnessTotal/5f;
            lume.intensity = brightness ;
            yield return new WaitForSeconds(0.1f);
        } 
    }
    private IEnumerator teleportCo(Collider player){
        yield return new WaitForSeconds(0.65f);
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        player.transform.position  = teleport.position;
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }

}
