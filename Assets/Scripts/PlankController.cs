using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankController : MonoBehaviour
{
    [SerializeField] private GameObject plank;

    [SerializeField] private GameObject square;
    // Start is called before the first frame update
    void Start()
    {
        plank.SetActive(false);
        square.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && (itemCollision.item2 == 1))
        {
            plank.SetActive(true);
            square.SetActive(false);
        }
    }
}
