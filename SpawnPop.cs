using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPop : MonoBehaviour
{
    
    public Transform moveToThis;
    public GameObject ypos;
    Camera cam;
    private Vector3 mousePosition;
    public GameObject spawner_point;
     public List <GameObject> pop;
     bool isC = false;

     public float yhighter;

    void Start()
    {
        yhighter = (Screen.height)/9;
       // transform.position = Vector2.Lerp(transform.position, ypos.position, 10f);
        cam = Camera.main;
        StartCoroutine(Spawn());
    }

    void Update()
    {
            //this.transform.position = Input.mousePosition;
            //transform.position = Vector2.Lerp(transform.position, ypos.transform.position, 5000f );
                var screenPoint = new Vector3(Input.mousePosition.x,Screen.height - yhighter, Input.mousePosition.z);
            screenPoint.z = 10.0f;
            moveToThis.position = Camera.main.ScreenToWorldPoint(screenPoint);
            
        if(Input.GetMouseButtonUp(0))
        {
            isC = false;
        }
        
    }
      IEnumerator Spawn()
      {
        while (true)
        {
            if(!isC)
        {
                int index = Random.Range(0, pop.Count);
                Instantiate(pop[index],moveToThis.position, moveToThis.rotation);
                isC = true;
        }
        yield return new WaitForSeconds(3f);
        }
        
    }   
}