using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Char1, Char2, Char3, Char4, Char5, Char6
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
