using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour

{
    public void Begin()
    {
        Debug.Log("button pressed");
        SceneManager.LoadScene("TreeScene");
    }

    public void End()
    {
        Debug.Log("end button pressed");

        Application.Quit();
    }

}