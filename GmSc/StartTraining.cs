using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTraining : MonoBehaviour
{
    private void Update()
    {
        if (LinesDrawer.alreadyDraw)
            this.gameObject.SetActive(false);
    }
}
