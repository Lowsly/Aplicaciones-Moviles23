using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    int round = 0, mx;
    public void Save(int round, int health, int mx, int power, int score)
    {
        PlayerPrefs.SetInt("round", round);
        PlayerPrefs.SetInt("CH", health);
        PlayerPrefs.SetInt("MH", mx);
        PlayerPrefs.SetInt("power", power);
        PlayerPrefs.SetInt("score", score);
        this.mx = mx;
    }
    public void Load()
    {
        PlayerPrefs.GetInt("round", 0);
        PlayerPrefs.GetInt("CH", 0);
    }
    public void New()
    {
        PlayerPrefs.SetInt("round", 0);
        PlayerPrefs.SetInt("CH", PlayerPrefs.GetInt("MH", 3));
        PlayerPrefs.SetInt("power", 1);
        PlayerPrefs.SetInt("score", 0);
    }
}

