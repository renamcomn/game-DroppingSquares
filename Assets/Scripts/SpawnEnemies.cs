using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject player;
    public float spawnerTime = 2f;
    public float counter = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= spawnerTime) {
            GameObject spawnedEnemy = Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, transform.rotation);
            Renderer enemyRenderer = spawnedEnemy.GetComponent<Renderer>();
            Renderer playerRenderer = player.GetComponent<Renderer>();

            if(enemyRenderer != null) {
                Material enemyMaterial = enemyRenderer.material;
                playerRenderer.material = enemyMaterial;
            }
            
            counter = 0f;
        }
        
    }
    
}
