using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnblock : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    [SerializeField] GameObject collectiblePrefab;
    public Transform spawnposition;
    public float collectibleChance = 0.6f;
    public float laneDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Spawnblock", 0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawnblock()
    {
        int randomindex = Random.Range(0, blocks.Length);
        GameObject block = Instantiate(blocks[randomindex], spawnposition.position, Quaternion.Euler(0,90,0));
        block.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (Random.value < collectibleChance)
        {
            Vector3 basePos = block.transform.position;
            float yOffset = 0;

            for (int lane = 0; lane < 3; lane++) 
            {
              
                if (Random.value < 0.7f) 
                {
                    float laneX = (lane - 1) * laneDistance;
                    Vector3 itemPos = new Vector3(laneX, basePos.y + yOffset, basePos.z);
                    GameObject collectible = Instantiate(collectiblePrefab, itemPos, Quaternion.identity);
                    collectible.transform.SetParent(block.transform);
                }
            }
        }
    }


}
