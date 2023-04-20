using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : MonoBehaviour
{

    Animation animations;
    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        animations.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
