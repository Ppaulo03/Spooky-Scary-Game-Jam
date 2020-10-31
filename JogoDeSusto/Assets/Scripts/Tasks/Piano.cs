using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{   
    [SerializeField] private List<AudioClip> notes = null;
    [SerializeField] private AudioClip desafinar = null;
    [SerializeField] private List<int> music = null;
    [SerializeField] private Signal cairNegocio = null, UIcommand = null;
    private int cont = 0;
    private bool win = false;
    private AudioSource myAudioSource;
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    public void play(int nota)
    {
        myAudioSource.loop = false;
        myAudioSource.clip =  notes[nota];
        myAudioSource.Play();
        if(!win)
        {
            if(music[cont] == nota)
            {
                cont ++;
                if(cont >= music.Count){
                    win = true;
                    StartCoroutine(delayCo());
                }
            }else{
                cont = 0;
                myAudioSource.loop = false;
                myAudioSource.clip =  desafinar;
                myAudioSource.Play();
            }
        }
    }
    private void OnDisable() {
        cont = 0;
    }

    private IEnumerator delayCo(){
        yield return new WaitForSeconds(1f);
        UIcommand.Raise();
        cairNegocio.Raise();
    }

}

