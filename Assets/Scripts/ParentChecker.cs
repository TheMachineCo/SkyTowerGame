using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChecker : MonoBehaviour
{
    void Update()
    {
        if (!transform.parent)
            Destroy(gameObject);
    }
}
