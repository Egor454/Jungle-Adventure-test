using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController 
{
    private GroundView groundView { get; set; }
    private GroundModel groundModel { get; set; }


    public GroundController(GroundView groundViews, GroundModel model)
    {
        this.groundView = groundViews;
        this.groundModel = model;

        groundView.GetDamage += GetDamageView;
        groundModel.Destroyed += DestroyedGround;

        groundModel.SendHealth += SendHealthView;
    }
    private void DestroyedGround(bool living)
    {
        groundView.DestroyedGroundView(living);
    }
    private void GetDamageView()
    {
        groundModel.ChangeHealth();
    }
    private void SendHealthView(int hp)
    {
        groundView.GetHealth(hp);
    }
}
