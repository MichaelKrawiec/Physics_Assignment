using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplodableFragments : ExplodableAddon{
    public override void OnFragmentsGenerated(List<GameObject> fragments)
    {
        foreach (GameObject fragment in fragments)
        {
            fragment.tag = "Explodable";
            Explodable fragExp = fragment.AddComponent<Explodable>();
            fragment.AddComponent<ExplodeOnClick>();

            fragExp.shatterType = explodable.shatterType;
            fragExp.fragmentLayer = explodable.fragmentLayer;
            fragExp.sortingLayerName = explodable.sortingLayerName;
            fragExp.orderInLayer = explodable.orderInLayer;

            fragment.layer = explodable.gameObject.layer;

            fragExp.fragmentInEditor();
        }
    }
}
