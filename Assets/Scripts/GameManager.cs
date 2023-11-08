using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static FireBoy FireBoy;
    public static WaterGirl WaterGirl;
    [SerializeField] IntToText CoinsText;
    [SerializeField] IntToText TimeText;
    [SerializeField] LevelExit LevelExit;
    public static int Coins;
    public static float Timer;
    public static Checkpoint Checkpoint;


    private void Start()
    {
        Timer = 120;
        Coins = 0;
        Checkpoint = null;
        FireBoy = transform.GetChild(0).gameObject.GetComponent<FireBoy>();
        WaterGirl = transform.GetChild(1).gameObject.GetComponent<WaterGirl>();
    }

    private void Update()
    {
        if (FireBoy.BoxColl.IsTouching(LevelExit.BoxColl)){
            if(Input.GetKey(KeyCode.E) && !LevelExit.IsLocked){
                FireBoy.ExitLevel = true;
                FireBoy.gameObject.SetActive(false);
            }
        }

        if (WaterGirl.BoxColl.IsTouching(LevelExit.BoxColl)){
            if(Input.GetKey(KeyCode.RightShift) && !LevelExit.IsLocked){
                WaterGirl.ExitLevel = true;
                WaterGirl.gameObject.SetActive(false);
            }
        }

        if (WaterGirl.ExitLevel && FireBoy.ExitLevel){
            //load end screen
        }

        if (!FireBoy.IsAlive || !WaterGirl.IsAlive){
            if (Checkpoint == null){
                SceneManager.LoadScene("GamePlay");
            }else{
                FireBoy.IsAlive = true;
                WaterGirl.IsAlive = true;
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
