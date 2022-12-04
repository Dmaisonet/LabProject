using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private int NUM_DISTRACTORS;
    private int level;
    [SerializeField] GameObject distractor;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if(level == 2) {
            NUM_DISTRACTORS = 3;
        }
        if(level == 3) {
            NUM_DISTRACTORS = 15;
        }
        if(level == 4) {
            NUM_DISTRACTORS = 40;
        }
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int xMin = -9;
        int xMax = 9;
        int yMin = 0;
        int yMax = 3;

        for (int i = 0; i < NUM_DISTRACTORS; i++)
        {

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(distractor, position, Quaternion.identity);
        }
    }
}
