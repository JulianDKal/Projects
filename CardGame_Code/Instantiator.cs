using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject Slot;
    GameObject newSlot;
    int slotCount = 0;

    void Start()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                newSlot = Instantiate(Slot, new Vector3(2.5f * x - 5, 3.3f * y - 2.05f, 0), Quaternion.identity);
                slotCount++;
                newSlot.name = slotCount.ToString();
            }
        }
    }
}
