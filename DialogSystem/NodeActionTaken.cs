namespace DialogSystem;

public struct NodeActionTaken
{
    public int NodeId { get; }
    public int ActionNumber { get; }

    public NodeActionTaken(int nodeId, int actionNumber)
    {
        NodeId = nodeId;
        ActionNumber = actionNumber;
    }
}