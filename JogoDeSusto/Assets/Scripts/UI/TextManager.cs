using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private TMPro.TMP_Text textBox;
    private Animator anim;
    private int cont = 0;

    [SerializeField] private List <string> text = null;
    [SerializeField] private List <float> time = null;
    [SerializeField] private Signal endText = null;
    
    void Start()
    {
        
        textBox = GetComponent<TMPro.TMP_Text>();
        anim = GetComponent<Animator>();
        if(cont >= text.Count || cont >= time.Count){
            Debug.Log("If errado");
            if(endText != null)endText.Raise();
        }
        else StartCoroutine(changeTextCo());
        
    }

    private IEnumerator changeTextCo()
    {
        textBox.text = text[cont];
        yield return new WaitForSeconds(time[cont]);
        anim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);

        cont ++;
        if(cont >= text.Count || cont >= time.Count){
            if(endText != null) endText.Raise();
        }
        else StartCoroutine(changeTextCo());           
    }
    
}
