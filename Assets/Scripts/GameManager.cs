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
    public static Checkpoint Checkpoint;

    private void Start()
    {
        Timer = 120;
        Coins = 0;
        Checkpoint = null;
    }

    private void Update()
    {
        if (!FireBoy.gameObject.activeSelf || !WaterGirl.gameObject.activeSelf){
            if (Checkpoint == null){
                SceneManager.LoadScene("GamePlay");
            }else{
                FireBoy.gameObject.SetActive(true);
                WaterGirl.gameObject.SetActive(true);
                FireBoy.transform.position = Checkpoint.Pos + new Vector3(-0.5f, 0f, 0f);
                WaterGirl.transform.position = Checkpoint.Pos + new Vector3(0.5f, 0f, 0f);
            }
        }

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
