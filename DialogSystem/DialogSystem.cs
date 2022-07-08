namespace DialogSystem
{
    public class DialogSystem
    {
        private readonly DialogNodeStructure _dialogNodeStructure;

        public DialogSystem(DialogNodeStructure dialogNodeStructure)
        {
            _dialogNodeStructure = dialogNodeStructure;
        }

        public NodeDialog GetNode(int nodeId) => _dialogNodeStructure.Exist(nodeId)
            ? _dialogNodeStructure.GetNode(nodeId)
            : NodeDialog.NotFound(nodeId);

        public NodeDialog ChooseAction(NodeActionTaken actionTaken)
        {
            var dialogNode = GetNode(actionTaken.NodeId);
            if (ExistsNode(actionTaken, dialogNode))
                if (ExistsActionInNode(actionTaken, dialogNode))
                    return GetNextNode(actionTaken, dialogNode);
            return NodeDialog.Empty();
        }

        private NodeDialog GetNextNode(NodeActionTaken actionTaken, NodeDialog dialogNode) =>
            GetNode(dialogNode.GetActions().FirstOrDefault(action => action.Number == actionTaken.ActionNumber)!.NextNodeId);

        private static bool ExistsActionInNode(NodeActionTaken actionTaken, NodeDialog dialogNode) =>
            dialogNode.GetActions().Exists(a => a.Number == actionTaken.ActionNumber);

        private static bool ExistsNode(NodeActionTaken actionTaken, NodeDialog dialogNode) =>
            dialogNode.GetId() == actionTaken.NodeId;
    }
}