using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour{
    [HideInInspector] public Rigidbody2D m_astroid_rb;
    public float astroidSpeed;
    SpawningAsteroid astroidManager;
    Camera cam;
    float x;
    float y;

    void Awake(){
        m_astroid_rb = gameObject.GetComponent<Rigidbody2D>();
        astroidManager = GameObject.Find("managerAstroid").GetComponent<SpawningAsteroid>();
        cam = Camera.main;
        x = cam.orthographicSize * Screen.width / Screen.height;
        y = cam.orthographicSize;
    }

    void Update(){
        if(Vector2.Distance((Vector2)transform.position,Vector2.zero) <= 2.8f){
            int side;
            side = Random.Range(0,4);

            switch (side){
                case 0:
                    transform.position = new Vector2(Random.Range(-x,x) , y);
                    break;
                case 1:
                    transform.position = new Vector2(x , Random.Range(-y,y));
                    break;
                case 2:
                    transform.position = new Vector2(Random.Range(-x,x) , -y);
                    break;
                case 3:
                    transform.position = new Vector2(-x , Random.Range(-y,y));
                    break;
            }
            m_astroid_rb.velocity = -transform.position.normalized * astroidSpeed;
        }
    }
}
