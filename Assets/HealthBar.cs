using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float orgScale = 1.5f;
        float endScale = 0.4f;

        Vector3 ypos = transform.position - transform.up;

        transform.localScale = new Vector3(transform.localScale.x, Mathf.MoveTowards(transform.localScale.y, endScale, 1));
        transform.position = ypos + (transform.up) * (transform.localScale.y / 2.0f + orgScale / 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
