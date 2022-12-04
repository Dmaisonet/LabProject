using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigid;
    [SerializeField] AudioSource audio;

    void Start()
    {   
       if (audio == null)
        {
          audio = GetComponent<AudioSource>();
        }
        rigid.velocity = transform.right*speed;

        DontDestroyOnLoad(audio);
    }

    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        Debug.Log("I HIT IT");
        Balloon balloon = hitInfo.GetComponent<Balloon>();
        Distractor distractor = hitInfo.GetComponent<Distractor>();
        Robot robot = hitInfo.GetComponent<Robot>();
        if(balloon != null)
        {   
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            float delay = 100;
            while((delay -= Time.deltaTime) > 0) 
            {
                
            }
            balloon.pop();
        }

        if(distractor != null)
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            distractor.pop();
        }
        Destroy(gameObject);
    }

   
}
