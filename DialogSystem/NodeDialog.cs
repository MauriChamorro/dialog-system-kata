namespace DialogSystem
{
    public class NodeDialog
    {
        private readonly int _id;
        private readonly string _txt;
        private readonly string _actionTxt;
        private readonly List<NodeAction> _nodeActions;

        public NodeDialog(int id, string txt, string actionTxt, List<NodeAction> nodeActions)
        {
            _id = id;
            _txt = txt;
            _actionTxt = actionTxt;
            _nodeActions = nodeActions;
        }

        public int GetId() => _id;

        public string GetText() => _txt;

        public string GetReaction() => _actionTxt;

        public List<NodeAction> GetActions() => _nodeActions;

        public static NodeDialog Empty() =>
            new NodeDialog(0, "", "", new List<NodeAction>());

        public static NodeDialog NotFound(int nodeId) =>
            new NodeDialog(-1, $"Node {nodeId} doesnt exist", "bug detected", new List<NodeAction>());
    }
}