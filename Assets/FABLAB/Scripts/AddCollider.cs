using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddColliderToChild(transform);

	}

   private void AddColliderToChild(Transform parent)
    {
        foreach(Transform child in parent)
        {
            if(child.GetComponent<Collider>() == null)
            {
                child.gameObject.AddComponent<MeshCollider>();
            }
            AddColliderToChild(child);
        }
    }
}
