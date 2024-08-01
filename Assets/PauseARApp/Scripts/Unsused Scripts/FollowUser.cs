using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUser : MonoBehaviour
{
    public Transform userTransform;

    // Update is called once per frame
    void Update()
    {
        if (userTransform != null)
        {
            transform.position = userTransform.position;
        }
    }
}
