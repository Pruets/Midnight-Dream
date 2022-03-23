using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text textHP;
    [SerializeField] private Text textCoin;
    [SerializeField] private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //pauseGame();
    }
    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu();
        }
    }
    public void showMenu()
    {
       // Audio_Manager.instance.playGUI();
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void hideMenu()
    {
        //Audio_Manager.instance.playGUI();
        panel.SetActive(false);
        Time.timeScale = 1;
    }
}
