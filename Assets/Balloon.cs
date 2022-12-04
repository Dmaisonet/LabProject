using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject controller;
    
    private Vector2 endpoint;
    private float timeLeft;
    private bool bouncex = false;
    private bool bouncey = false;
    private int pointsToAdd = 50;

    float xMin = -10.0f;
    float xMax = 10.0f;
    float yMin = -1.0f;
    float yMax = 3.0f;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
      if (controller == null)
      {
          controller = GameObject.FindGameObjectWithTag("GameController");
      }

      if (rigid == null)
      {
        rigid = GetComponent<Rigidbody2D>();
      }

      if (SceneManager.GetActiveScene().buildIndex == 4)
      {
        //make balloon flee from left to right on third level
        rigid.velocity = fleeingBalloon();
      }else
      {
        rigid.velocity = RandomPosition();
      }
      
      InvokeRepeating("getBigger", 0.1f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.x <= xMin || transform.position.x >= xMax) {
        if(bouncex == false) {
          rigid.velocity = new Vector2(rigid.velocity.x * -1, rigid.velocity.y);
          bouncex = true;
        }
        
      }
      if(transform.position.y <= yMin || transform.position.y>= yMax) {
        if(bouncey == false) {
          rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * -1);
          bouncey = true;
        }
        
      }

      resetBounce();

      if(SceneManager.GetActiveScene().buildIndex == 4 && hasFled())
      {
        //if level 3 and balloon fled then reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
    
    }

    void getBigger()
    {
      if(count < 45)
      {
        Vector3 scale = transform.localScale;
        scale.x += 0.001f;
        scale.y += 0.001f;
        transform.localScale = scale;
        count++;
        pointsToAdd--;
      }else
      {
        //reload b/c you suck
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      
    }

    private Vector2 RandomPosition()
    {
      float x = Random.Range(xMin, xMax);
      float y = Random.Range(yMin, yMax);
      return new Vector2(x,y);
    }

    void resetBounce()
    {
      if(transform.position.x > -1 && transform.position.x < 1) //range of values to make sure bounce is calculated
      {
        bouncex = false;
      }

      if(transform.position.y > -1 && transform.position.y < 2)
      {
        bouncey = false;
      }
    }

    public void pop()
    {
      //add points here
      controller.GetComponent<Scorekeeper>().AddPoints(pointsToAdd);
      controller.GetComponent<Scorekeeper>().DisplayScore();
      
      Destroy(gameObject);
    }

    private Vector2 fleeingBalloon()
    {
      float x = 1;
      float y = Random.Range(yMin, yMax);
      return new Vector2(x*10, y);
    }

    private bool hasFled()
    {
      //return true if balloon has fled
      return(transform.position.x < 10)? false:true;
    }

    

}
