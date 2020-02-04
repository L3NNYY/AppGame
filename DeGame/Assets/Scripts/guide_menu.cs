using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class guide_menu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
