using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float LifeTimer;

    private void Start()
    {
        Destroy(gameObject, LifeTimer);
    }
}
