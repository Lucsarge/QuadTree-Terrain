using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpatialTree;

public class QuadTreeComponent : MonoBehaviour
{
    QuadTree quadTree;

    // Start is called before the first frame update
    void Start()
    {
        quadTree = new QuadTree(this.transform.position, 50);
        print(quadTree.ToString());
        print(quadTree.nodes[0].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if(quadTree != null)
        {
            Gizmos.DrawWireCube(quadTree.coordinates, new Vector3(quadTree.size, quadTree.size));
            DrawBox(quadTree.nodes);
        }

        void DrawBox(QuadTree[] nodes)
        {
            foreach (QuadTree node in nodes)
            {
                if (node != null)
                {
                    Gizmos.DrawWireCube(node.coordinates, new Vector3(node.size, node.size));
                    if (node.nodes != null) { DrawBox(node.nodes); }
                }
            }
        }
    }

    
}
