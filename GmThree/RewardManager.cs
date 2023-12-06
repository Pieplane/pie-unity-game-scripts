using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private GameObject PileOfCoinParent;
    [SerializeField] private TextMeshProUGUI Counter;
    private Vector3[] InitialPos;
    private Quaternion[] InitialRotation;

    private void Start()
    {
        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            InitialPos[i] = PileOfCoinParent.transform.GetChild(i).position;
            InitialRotation[i] = PileOfCoinParent.transform.GetChild(i).rotation;
        }
    }
    private void Reset()
    {
        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
            PileOfCoinParent.transform.GetChild(i).position = InitialPos[i];
            PileOfCoinParent.transform.GetChild(i).rotation = InitialRotation[i];
        }
    }
    private void RewardPileOfCoin(int No_Coin)
    {
        Reset();


        PileOfCoinParent.SetActive(true);

        for (int i = 0; i < PileOfCoinParent.transform.childCount; i++)
        {
        }
    }
}
