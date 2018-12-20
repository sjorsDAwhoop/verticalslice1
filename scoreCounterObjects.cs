using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCounterObjects : MonoBehaviour {

    [SerializeField]
    private int scoreValue;

    private scoreCounter scorecounter;
    private Catapult catapult;

    void Start()
    {
        scorecounter = GameObject.FindObjectOfType<scoreCounter>();
        catapult = GameObject.FindObjectOfType<Catapult>();
        Debug.Log(scorecounter.Score);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0 && catapult.PointsActive == true)
        {
            scoreValue = Mathf.RoundToInt(collision.relativeVelocity.magnitude) * 50;
            Debug.Log(scoreValue);
            scorecounter.Score += scoreValue;
        }

        if (scoreValue >= 250)
        {
            scoreValue += 500;
            Destroy(gameObject);
        }
    }
}
