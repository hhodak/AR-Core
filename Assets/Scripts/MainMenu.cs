using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void ReturnToMainMenu(GameObject currentPanel)
    {
        mainMenu.SetActive(true);
        currentPanel.SetActive(false);
    }

    public void OpenPanel(GameObject selectedPanel)
    {
        selectedPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
