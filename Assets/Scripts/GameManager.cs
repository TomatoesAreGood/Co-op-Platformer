using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static FireBoy FireBoy;
    public static WaterGirl WaterGirl;
    public static int Coins;
    public static float Timer;
    public static Checkpoint Checkpoint;
    [SerializeField] IntToText _coinsText;
    [SerializeField] IntToText _timeText;
    [SerializeField] Door _levelExit;
    [SerializeField] GameObject _endScreen;
    private int _numTrophies;


    private void Start()
    {
        _numTrophies = 0;
        Timer = 120;
        Coins = 0;
        Checkpoint = null;
        FireBoy = transform.GetChild(0).gameObject.GetComponent<FireBoy>();
        WaterGirl = transform.GetChild(1).gameObject.GetComponent<WaterGirl>();
    }

    private void Update()
    {
        if (FireBoy.BoxColl.IsTouching(_levelExit.BoxColl)){
            if (!_levelExit.IsLocked){
                if(Input.GetKey(KeyCode.E)){
                    FireBoy.ExitLevel = true;
                    FireBoy.gameObject.SetActive(false);
                }   
                if (FireBoy.HeldItem is Trophy){
                    _numTrophies++;
                    if (FireBoy.HeldItem.gameObject != null) {
                        Destroy(FireBoy.HeldItem.gameObject);
                    }
                    FireBoy.HeldItem = null;
                }
            }
           
        }

        if (WaterGirl.BoxColl.IsTouching(_levelExit.BoxColl)){
            if (!_levelExit.IsLocked){
                if(Input.GetKey(KeyCode.RightShift)){
                    WaterGirl.ExitLevel = true;
                    WaterGirl.gameObject.SetActive(false);
                }
                if (WaterGirl.HeldItem is Trophy){
                    _numTrophies++;
                    if (WaterGirl.HeldItem.gameObject != null) {
                        Destroy(WaterGirl.HeldItem.gameObject);
                    }
                    WaterGirl.HeldItem = null;
                }
            }
        }

        if (WaterGirl.ExitLevel && FireBoy.ExitLevel){
            LoadEndScreen();
            WaterGirl.ExitLevel = false;
        }

        if (!FireBoy.IsAlive || !WaterGirl.IsAlive){
            if (Checkpoint == null){
                SceneManager.LoadScene("Level 1");
            }else{
                FireBoy.IsAlive = true;
                WaterGirl.IsAlive = true;
                FireBoy.transform.position = Checkpoint.Pos + new Vector3(-0.5f, 0f, 0f);
                WaterGirl.transform.position = Checkpoint.Pos + new Vector3(0.5f, 0f, 0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Level 1");
        }

        Timer -= Time.deltaTime;
        if (Timer == 0){
            Application.Quit();
        }
        _timeText.UpdateText((int)Timer);
        _coinsText.UpdateText(Coins);
    }

    private void LoadEndScreen(){
        GameObject star1 = _endScreen.transform.GetChild(0).gameObject;
        GameObject star2 = _endScreen.transform.GetChild(1).gameObject;
        GameObject star3 = _endScreen.transform.GetChild(2).gameObject;

        _endScreen.transform.GetChild(3).GetComponent<TextMesh>().text = "Coins: " + Coins;
        _endScreen.transform.GetChild(4).GetComponent<TextMesh>().text = "Trophies: " + _numTrophies;
        int score = Coins + _numTrophies*50;
        _endScreen.transform.GetChild(5).GetComponent<TextMesh>().text = "Score: " + score;

        if (score < 50){
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }else if (score < 100){
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }else{
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        StartCoroutine(StartEndScreen());
    }

    private IEnumerator StartEndScreen(){
        yield return new WaitForSeconds(1);
        float startingPos = -24.06f;
        float endPos = 12.33f;
        for (float i = 0; i < 1; i += 0.01f){
            _endScreen.transform.position = new Vector3(Mathf.Lerp(startingPos, endPos, i), -4.49f,transform.position.z);
            yield return new WaitForSeconds(0.02f);
        }

    }
}
