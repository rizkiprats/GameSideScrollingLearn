
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // public GameObject enemySmallPrefab;
    // public GameObject enemyMediumPrefab;
    // public GameObject enemyBigPrefab;

    public spawnrate[] enemies;

    public float delaySpawner;

    private List<GameObject> enemylist;

    // Start is called before the first frame update
    void Start()
    {
        enemylist = new List<GameObject>();
        StartCoroutine(Spawner());

    }

    // Update is called once per frame
    private IEnumerator Spawner()
    {
        while (true)
        {
            spawn();
            yield return new WaitForSecondsRealtime(delaySpawner);
        }
    }

    private GameObject getEnemy()
    {
        int limit = 0;

        foreach (spawnrate osr in enemies)
        {
            limit += osr.rate;
        }


        int random = Random.Range(0, limit);

        foreach (spawnrate osr in enemies)
        {
            if (random < osr.rate)
            {
                return osr.prefabs;
            }
            else
            {
                random -= osr.rate;
            }
        }
        return null;

    }

    public void spawn()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-11.5f, 15.5f);
        enemylist.Add(Instantiate(getEnemy(), newPosition, transform.rotation));
    }

    public void clearEnemies()
    {
        foreach (GameObject go in enemylist)
        {
            Destroy(go);
        }
        enemylist.Clear();

    }
}
