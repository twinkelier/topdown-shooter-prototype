using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour
{
    [SerializeField] SfxManager sfxManager;
    public void StartButton()
    {
        print("boop");
        sfxManager.sfxInstance.AudioSource.PlayOneShot(sfxManager.sfxInstance.clickSound);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        sfxManager.sfxInstance.AudioSource.PlayOneShot(sfxManager.sfxInstance.clickSound);
        Application.Quit();
    }
}
