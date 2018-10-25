using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Transforms;

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
    public Dictionary<string, Node> GetAccessibleArea(Node begNode, float value)
    {
        Dictionary<string, Node> ret = new Dictionary<string, Node>();
        Stack<StackNode> tmpFindStack = new Stack<StackNode>();
        tmpFindStack.Push(new StackNode{value = value,node = begNode });
        while (tmpFindStack.Count != 0) {
            var node = tmpFindStack.Pop();
            if (node.value < 0)
            {
                continue;
            }
            ret.Add(node.node.ID(), node.node);
            foreach (var no in node.node.GetAllAdjacentNodes()) {
                if (node.value - no.Cost() >= 0) {
                    tmpFindStack.Push(new StackNode { value = node.value - no.Cost(), node = no});
                }
            }
        }
        return ret;
    }
}
