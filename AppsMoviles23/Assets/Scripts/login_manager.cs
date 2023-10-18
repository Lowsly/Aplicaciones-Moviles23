using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class login_manager : MonoBehaviour
{
    [SerializeField] GameObject MainWindow;
    [SerializeField] GameObject UserManager;

    [Space]
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_Text ErrorMsg;
    [SerializeField] Button LoginButton;

    [Space]
    [SerializeField] string url;
    WWWForm form;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey ("username"))
        {
            MainWindow.SetActive(true);
            UserManager.SetActive(true);
            Debug.Log("<color=green> Éxito con inicio de sesión </color>");
        }
           
    }

    public void OnLoginButtonClicked()
    {
        LoginButton.interactable = false;
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        form = new WWWForm();
        
        form.AddField("username", username.text);
        form.AddField("password", password.text);

        Debug.Log("Enviando usuario: " + username.text);
        Debug.Log("Enviando contraseña: " + password.text);

        WWW w = new WWW(url, form);

        yield return w;

        if(w.error != null)
        {
            ErrorMsg.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");

            Debug.Log("Error en la conexión: " + w.error);
        }
        else
        {
            if(w.isDone)
            {
                if(w.text.Contains("Error"))
                {
                    ErrorMsg.color = Color.red;
                    ErrorMsg.text = "Invalid username or password";
                    Debug.Log("<color=red>" + w.text + "</color>");
                }
                else
                {
                    MainWindow.SetActive(true);
                    
                    string fetch_value = w.text;
                    string[] value_array;
                    value_array = fetch_value.Split('|');

                    PlayerPrefs.SetString("username", value_array[1]);
                    PlayerPrefs.SetString("email", value_array[2]);
                    PlayerPrefs.Save();
                }
            }

            LoginButton.interactable = true;
            UserManager.SetActive(true);

            Debug.Log("Respuesta del servidor: " + w.text);
            
            w.Dispose();
        }    
    }
}
