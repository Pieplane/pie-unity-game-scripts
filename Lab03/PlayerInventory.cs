using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCarrots { get; private set; }

    public void CarrotCollected()
    {
        NumberOfCarrots++;
    }
}
