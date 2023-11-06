using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] FireBoy fireBoy;
    [SerializeField] WaterGirl waterGirl;

    [SerializeField] IntToText coinsText;

    [SerializeField] IntToText timeText;


    public static int Coins;
    public static float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 120;
        Coins = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("GamePlay");
        }

        Timer -= Time.deltaTime;
        if (Timer == 0){
            Application.Quit();
        }
        timeText.UpdateText((int)Timer);
        coinsText.UpdateText(Coins);
    }
}
