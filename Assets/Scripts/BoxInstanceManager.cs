using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxInstanceManager : MonoBehaviour
{
    public GameEvents gameEvents;

    public GameObject woodenBox;
    public GameObject ironBox;
    public GameObject bigWoodenBox;
    public GameObject stoneBox;

    private void Start()
    {
        
        for (int j = -2; j < 2; j++)
        {
            for (int i = -3; i < 2; i++)
            {
                GameObject pref;
                var ran = Random.Range(0.0f, 10.0f);
                if (ran >  Random.Range(3f, 8f))
                {
                    pref = bigWoodenBox;
                    gameEvents.numberOfBreakableBoxes++;
                }
                else
                {
                    continue;
                }

                var g = Instantiate(pref,
                    new Vector3(
                        this.gameObject.transform.position.x + i * 1.51f,
                        this.gameObject.transform.position.y ,
                        this.gameObject.transform.position.z + j * 1.51f
                    ),
                    Quaternion.identity,
                    this.gameObject.transform);
            }
        }
        
        for (int j = -6; j < 5; j++)
        {
            for (int i = -12; i < 6; i++)
            {
                GameObject pref;
                var ran = Random.Range(0.0f, 10.0f);
                if (ran > 6)
                {
                    pref = woodenBox;
                    gameEvents.numberOfBreakableBoxes++;
                }
                else if (ran > 4.5)
                {
                    pref = ironBox;
                    gameEvents.numberOfBreakableBoxes++;
                }
                else if (ran > 0.5)
                {
                    continue;
                }
                else
                {
                    pref = stoneBox;
                }

                var g = Instantiate(pref,
                    new Vector3(
                        this.gameObject.transform.position.x + i * 0.51f,
                        this.gameObject.transform.position.y+ 2 * 0.7f,
                        this.gameObject.transform.position.z + j * 0.51f
                    ),
                    Quaternion.identity,
                    this.gameObject.transform);
            }
        }

    }
}