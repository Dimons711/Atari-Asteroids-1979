using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundry : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionExit(Collision other)
    {
        Destroy(other.gameObject);
    }
}