using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController 
{
    private GroundView groundView { get; set; }
    private GroundModel groundModel { get; set; }


    public GroundController(GroundView groundView, GroundModel model)
    {
        this.groundView = groundView;
        this.groundModel = model;

        groundView.GetDamage += GetDamageView;
        groundModel.Destroyed += DestroyedGround;
    }
    private void DestroyedGround(bool living)
    {
        groundView.DestroyedGroundView(living);
    }
    private void GetDamageView()
    {
        groundModel.ChangeHealth();
    }
}
