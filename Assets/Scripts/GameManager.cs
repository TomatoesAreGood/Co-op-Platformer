using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] FireBoy FireBoy;
    [SerializeField] WaterGirl WaterGirl;
    [SerializeField] IntToText CoinsText;
    [SerializeField] IntToText TimeText;
    public static int Coins;
    public static float Timer;

    private void Start()
    {
        Timer = 120;
        Coins = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("GamePlay");
        }

        Timer -= Time.deltaTime;
        if (Timer == 0){
            Application.Quit();
        }
        TimeText.UpdateText((int)Timer);
        CoinsText.UpdateText(Coins);
    }
}
