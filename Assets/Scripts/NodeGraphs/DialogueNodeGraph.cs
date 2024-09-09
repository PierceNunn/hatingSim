using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class DialogueNodeGraph : NodeGraph
{
    public IntroNode findIntroNode()
    {
        for(int i = 0; i < nodes.Count; i++)
        {
            Debug.Log(nodes[i].GetType());
            if(nodes[i].GetType().ToString().Equals("IntroNode"))
                return nodes[i] as IntroNode;
        }
        return null;
    }
}
