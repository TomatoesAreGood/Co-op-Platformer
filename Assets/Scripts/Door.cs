using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsLocked;
    private int _keys;
    public BoxCollider2D BoxColl;
    private GameObject _lockIcon;
    private Animator _anim;
    private GameObject _twoIcon;
    private GameObject _oneIcon;

    private void Start(){
        IsLocked = true;
        _keys = 2;
        _anim = GetComponent<Animator>();
        BoxColl = GetComponent<BoxCollider2D>();
        _lockIcon = transform.GetChild(0).gameObject;
        _twoIcon = transform.GetChild(1).gameObject;
        _oneIcon = transform.GetChild(2).gameObject;
    }
    private void Update(){
        if (BoxColl.IsTouching(GameManager.WaterGirl.BoxColl)){
            if (GameManager.WaterGirl.HeldItem is Key){
                _keys--;
                Destroy(GameManager.WaterGirl.HeldItem.gameObject);
                GameManager.WaterGirl.HeldItem = null;
                if (_keys == 0){
                    IsLocked = false;
                }
            }
            if (IsLocked){
                _anim.SetBool("CanEnterDoor", false);
            }else{
                _anim.SetBool("CanEnterDoor", true);
            }
        }   
        if (BoxColl.IsTouching(GameManager.FireBoy.BoxColl)){
            if (GameManager.FireBoy.HeldItem is Key){
                _keys--;
                Destroy(GameManager.FireBoy.HeldItem.gameObject);
                GameManager.FireBoy.HeldItem = null;
                if (_keys == 0){
                    IsLocked = false;
                }            
            }
            if (IsLocked){
                _anim.SetBool("CanEnterDoor", false);
            }else{
                _anim.SetBool("CanEnterDoor", true);
            }
        }

        if (_keys == 2){
            _twoIcon.SetActive(true);
            _oneIcon.SetActive(false);
        }else if (_keys == 1){
            _twoIcon.SetActive(false);
            _oneIcon.SetActive(true);
        }else if (_keys == 0){
            _twoIcon.SetActive(false);
            _oneIcon.SetActive(false);
        }

        if (IsLocked){
            _lockIcon.SetActive(true);
        }else{
            _lockIcon.SetActive(false);
        }
    }
}
