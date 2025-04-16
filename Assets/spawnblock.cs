using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnblock : MonoBehaviour
{
    [SerializeField]
    GameObject[] blocks;
    public Transform spawnposition;

    // Start is called before the first frame update
    void Start()
    {
        Spawnblock();
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
    }


}
