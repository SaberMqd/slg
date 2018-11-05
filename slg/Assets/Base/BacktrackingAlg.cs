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
        public Node from_node;
    }
    static public Dictionary<string, Node> GetAccessibleArea(Node begNode, float value)
    {
        Dictionary<string, Node> ret = new Dictionary<string, Node>();
        Stack<StackNode> tmpFindStack = new Stack<StackNode>();
        tmpFindStack.Push(new StackNode{value = value,node = begNode, from_node = begNode });

        while (tmpFindStack.Count != 0) {
            var node = tmpFindStack.Pop();
            if (node.value < 0)
            {
                continue;
            }
            ret.Add(node.node.ID(), node.node); 
            foreach (var no in node.node.GetAllAdjacentNodes()) {
                if (no.ID() == node.from_node.ID()) {
                    continue; 
                }
                if (node.value - no.Cost() >= 0) {
                    tmpFindStack.Push(new StackNode { value = node.value - no.Cost(), node = no});
                }
            }
        }
        return ret;
    }
}
