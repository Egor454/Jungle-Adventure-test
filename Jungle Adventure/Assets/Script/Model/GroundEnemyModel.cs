﻿using UnityEditor;
using UnityEngine.Events;

public class GroundEnemyModel
{
    private float speed = 1f;
    public event UnityAction<float> ChangedEnemyPositionModel;

    public void ChangePositionEnemy(bool enemy)
    {
        if (enemy)
        {
            ChangedEnemyPositionModel?.Invoke(speed);
        }

    }


}
    