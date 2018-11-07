using System.Collections.Generic;

public class BacktrackingAlg
{
    public interface Node
    {
        Node[] GetAllAdjacentNodes();
        float Cost();
        string ID();
    }

    private struct StackNode
    {
        public float value;
        public Node node;
    }
    static public Dictionary<string, Node> GetAccessibleArea(Node begNode, float value)
    {
        Dictionary<string, Node> ret = new Dictionary<string, Node>();
        Stack<StackNode> tmpFindStack = new Stack<StackNode>();
        tmpFindStack.Push(new StackNode{value = value,node = begNode});

        int i = 0;
        while (tmpFindStack.Count != 0) {
            var node = tmpFindStack.Pop();
            if (node.value < 0)
            {
                continue;
            }
            //UnityEngine.Debug.Log(node.node.ID()+"  value is " + node.value);
            if (!ret.ContainsKey(node.node.ID())) {
                ret.Add(node.node.ID(), node.node);
            }
            if (node.node.GetAllAdjacentNodes() == null) {
                continue;  
            }
            foreach (var no in node.node.GetAllAdjacentNodes()) {
                tmpFindStack.Push(new StackNode { value = node.value - no.Cost(), node = no});
            }
            i++;
            if (i == 20) {
                break;
            }
        }

        return ret;
    }
}
