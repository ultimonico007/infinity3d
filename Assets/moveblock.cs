using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveblock : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed* Time.deltaTime);
       
    }
}
