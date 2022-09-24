namespace Keeper.Models
{
    public class Vault
    {
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public bool isPrivate { get; set; }
        public Profile Creator { get; set; }
    }
}