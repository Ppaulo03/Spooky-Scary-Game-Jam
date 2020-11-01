using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChooseLevel(string level)
    {
        StartCoroutine(ChooseLevelCo(level));
    }

    private IEnumerator ChooseLevelCo(string level)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);
        while(!asyncOperation.isDone){
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
