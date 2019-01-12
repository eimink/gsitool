using CSGSI.Nodes;

namespace gsitool
{
    class PlayerIdNode
    {
        public string Name;
        public string SteamID;

        public PlayerIdNode(PlayerNode node)
        {
            this.Name = node.Name;
            this.SteamID = node.SteamID;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
