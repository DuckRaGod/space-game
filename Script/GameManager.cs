using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    [SerializeField] private GameObject[] startObject;
    [SerializeField] private GameObject menu;
    [SerializeField] private Transform space;
    [SerializeField] private SpawningAsteroid astroidManager;

    void Update(){
        if(menu.activeSelf == true && Input.GetKeyDown("space")){
            foreach (GameObject item in startObject){
                item.SetActive(true);
            }
            menu.SetActive(false);
            astroidManager.spawnAstroid();
        }
        spaceRotate();
        if(Input.GetKeyDown("escape")){
            Application.Quit();
        }
    }

    void spaceRotate(){
        space.Rotate(0,0,Time.deltaTime * 1.5f);
    }
}
