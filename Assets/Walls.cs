using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            print("Enemy Collision");
        }
    }
}
