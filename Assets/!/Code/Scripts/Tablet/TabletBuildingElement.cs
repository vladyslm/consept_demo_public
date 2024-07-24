using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletBuildingElement : MonoBehaviour
{
    [SerializeField] private TabletController _tabletController;

    [SerializeField] private BuildableSO _blueprintItem;

    public void NotifyTablet()
    {
        _tabletController.Notify(_blueprintItem);
    }
}