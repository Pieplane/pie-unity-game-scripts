using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    private int modifiers;

    public int GetValue()
    {
        int finalValue = modifiers;
        return finalValue;
    }

    public void AddModifier (int modifier)
    {
        if(modifier != 0)
        {
            modifiers = modifier;

        }
    }

}
