using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour{
    [SerializeField] private SpawningAsteroid manager;
    [SerializeField] private float r;
    [SerializeField] private float speed;
    [SerializeField] private float b;
    float a = 0;
    float dir = 0;
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        if(r <= 0){
            r = 1;
        }
        if(speed <= 0){
            speed = 1;
        }
    }

    void Update(){
        a += Time.deltaTime * speed * dir;
        if(a * Mathf.Rad2Deg > 360){
            a = 0;
        }
        playerInput();
        shipMoveRot();
    }

    void shipMoveRot(){
        transform.rotation = Quaternion.Euler(0,0,a * Mathf.Rad2Deg);
        Vector2 pos = new Vector2(Mathf.Cos(a) * r,Mathf.Sin(a) * r);
        transform.position = pos;
    }

    void playerInput(){
        if(Input.GetKeyDown("space")){
            if(dir == 1){
                dir = -1;
            }
            else{
                dir = 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.transform.CompareTag("Astroid")){
            coll.gameObject.SetActive(false);
            manager.spawnAstroid();
        }
    }
}
