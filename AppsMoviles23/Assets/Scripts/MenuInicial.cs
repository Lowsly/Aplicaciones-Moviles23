using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public string scene;
    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
