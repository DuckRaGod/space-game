using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningAsteroid : MonoBehaviour{
    Camera cam;
    float x;
    float y;
    [SerializeField] private GameObject astroidPrefab;
    Queue<GameObject> astroids = new Queue<GameObject>();
    [SerializeField] private int amountOfAstroid;

    void Awake(){
        cam = Camera.main;
        x = cam.orthographicSize * Screen.width / Screen.height;
        y = cam.orthographicSize;

        spawnNewAstroid(amountOfAstroid);
    }

    void spawnNewAstroid(int amountOfAstroid){
        for(int i = 0; i < amountOfAstroid ; i++){
            GameObject obj = Instantiate(astroidPrefab);
            astroids.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    public void spawnAstroid(){
        GameObject m_astroid = astroids.Dequeue();
        m_astroid.SetActive(true);
        astroids.Enqueue(m_astroid);
        int side;
        side = Random.Range(0,4);

        switch (side){
            case 0:
                m_astroid.transform.position = new Vector2(Random.Range(-x,x) , y);
                break;
            case 1:
                m_astroid.transform.position = new Vector2(x , Random.Range(-y,y));
                break;
            case 2:
                m_astroid.transform.position = new Vector2(Random.Range(-x,x) , -y);
                break;
            case 3:
                m_astroid.transform.position = new Vector2(-x , Random.Range(-y,y));
                break;
        }
        m_astroid.GetComponent<astroid>().m_astroid_rb.velocity = -m_astroid.transform.position.normalized * m_astroid.GetComponent<astroid>().astroidSpeed;
    }
}
 