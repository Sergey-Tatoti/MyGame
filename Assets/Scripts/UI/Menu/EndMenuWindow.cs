using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuWindow : MonoBehaviour
{
    [SerializeField] private EndGameMenu _endGameMenu;

    public void ShowMenu()
    {
        _endGameMenu.gameObject.SetActive(true);
    }
}
