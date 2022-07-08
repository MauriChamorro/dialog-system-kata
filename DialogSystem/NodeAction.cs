namespace DialogSystem
{
    public class NodeAction
    {
        public int Number { get; }
        public string ActionTxt { get; }
        public int NextNodeId { get; }

        public NodeAction(int number, string actionTxt, int nextNodeId)
        {
            Number = number;
            ActionTxt = actionTxt;
            NextNodeId = nextNodeId;
        }
    }
}