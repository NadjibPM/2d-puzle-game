using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    Rigidbody2D  rb;
    public Transform spawner;
    private Vector3 mousePosition;
    public Transform moveToThis;
    Camera cam;
    public float moveSpeed = 3f;
    public ParticleSystem explosion;
    private GameObject ypo;
    private float timer;
    public bool gg;
    public float yhight;
    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        yhight = (Screen.height)/9;
        gg = false;
        timer = 1f;
        //transform.position = Vector2.Lerp(transform.position, spawner.position, moveSpeed );
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.isKinematic = false;
        }
        if (rb.isKinematic == true)
        {
            
            ypo =  GameObject.FindWithTag("Player");
            var screenPoint = new Vector3(Input.mousePosition.x,Screen.height - yhight, Input.mousePosition.z);
            screenPoint.z = 10.0f;
            moveToThis.position = Camera.main.ScreenToWorldPoint(screenPoint);
        }
    }
    private void OnCollisionEnter2D (Collision2D col)
    {
        
        if(col.gameObject.tag == gameObject.tag){
            List <GameObject> c = new List <GameObject>();
            c.Add(gameObject);
            c.Add(col.gameObject);
            GameManager.updateCollisionList(c);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
    }
        private void OnTriggerStay2D(Collider2D other)
    {
        if (rb.isKinematic == false )
        {
            timer -= Time.deltaTime;
         if(timer <= 0)
         {
            gg = true;
         }
        }
        
    }
    private void OnTriggerExit2D(Collider2D co)
    {
        timer = 2f;
    }
}