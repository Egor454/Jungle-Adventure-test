using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    #region SerializedField

    [SerializeField] private Animator anim;

    #endregion SerializedField

    #region Private Fields

    private BoxCollider2D boxCest;
    private Chest chest;

    #endregion Private Fields

    #region Private Methods

    private void Start()
    {
        anim.SetBool("Open", false);
        boxCest = GetComponent<BoxCollider2D>();
        chest = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Open", true);
            boxCest.enabled = false;
            
        }
    }

    #endregion Private Methods
}
