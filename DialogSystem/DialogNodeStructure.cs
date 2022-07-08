namespace DialogSystem
{
    public class DialogNodeStructure
    {
        private readonly Dictionary<int, NodeDialog> _dictionaryEntry = new();

        public DialogNodeStructure(List<NodeDialog> dialogNodes) => 
            dialogNodes.ForEach(dn => _dictionaryEntry.Add(dn.GetId(), dn));

        public bool Exist(int nodeId) =>
            _dictionaryEntry.ContainsKey(nodeId);

        public NodeDialog GetNode(int nodeId) =>
            _dictionaryEntry[nodeId];
    }
}