using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("asdf");
        Application.Quit();
    }
}
