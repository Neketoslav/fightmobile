using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crime : DataPlayer
{
    private int _countCrime;
    public int CountCrime
    {
        get => _countCrime;
        set
        {
            if (_countCrime != value)
            {
                _countCrime = value;
                Notifier(DataType.Crime);
            }
        }
    }
}
