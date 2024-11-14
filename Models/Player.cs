namespace WPF_MVVM.Models
{
    public class Player
    {
        public string Name { get; init; }
        public string Score { get; set; }

        public Player(string name, string score)
        {
            Name = name;
            Score = score;
        }
    }
}
