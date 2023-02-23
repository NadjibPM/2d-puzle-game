using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static List <List <GameObject>> currentCollisions = new List <List <GameObject>> ();
    CircleCollider2D m_Collider;
    Rigidbody2D  rb;
    public List <GameObject> upup;
    public TextMeshProUGUI scoreText;
    public GameObject spawn;
    private int score;
    [SerializeField] GameObject CanvasGameOver; 
    [SerializeField] string[] tags;

    void Start()
    {
        score = 0 ;
        UpdateScore (0);
    }

    void Update()
    {
        //RemoveAt
        List <List <GameObject>> myCols = new List <List <GameObject>> (currentCollisions);
        foreach (List <GameObject> c in myCols){
            Destroy(c[0]);
            Destroy(c[1]);
            int index = (upup.FindIndex(a => c[0].tag == a.tag)+1)%upup.Count;
            GameObject a = Instantiate(upup[index]);
            m_Collider = a.GetComponent<CircleCollider2D>();
            Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            m_Collider.enabled = true;
            a.transform.position = (c[1].transform.position);
            currentCollisions.Remove(c);
            UpdateScore(index*index);
            gameObject.GetComponent<AudioSource>().Play();
        } 
        foreach (string tag in tags)
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject g in go)
            {
                if (g.GetComponent<Target>().gg == true )
                {
                    CanvasGameOver.SetActive(true);
                    spawn.SetActive(false);
                }
            }
        }
    }

    public static void updateCollisionList(List <GameObject> col){
        bool isIn = false;
        foreach (List <GameObject> c in currentCollisions){
            if(((c[0].tag == col[0].tag) && (c[1].tag == col[1].tag)) || ((c[0].tag == col[1].tag) && (c[1].tag == col[0].tag))){
                isIn = true;
            }
        }
        if(!isIn){
            currentCollisions.Add(col);
        }
    }

    void UpdateScore (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}