using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private Button button;

    public void OnButtonClick()
    {
        SceneManager.LoadScene("MyLauncher");
    }
}
