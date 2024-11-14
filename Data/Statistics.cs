using System.Collections.ObjectModel;
using System.Linq;

using WPF_MVVM.Models;

namespace WPF_MVVM.Data
{
    public class Statistics
    {
        private const string jsonPath = "Statistics.json";
        public static ObservableCollection<Player> Players { get => JsonFileManager.ReadListFromJsonFile<Player>(jsonPath); }

        public static void Add(string name, string score)
        {
            Player player = new(name, score);
            ObservableCollection<Player> players = JsonFileManager.ReadListFromJsonFile<Player>(jsonPath);

            if (players.Any(p => p.Name == player.Name))
            {
                Player writedPlayer = players.FirstOrDefault(p => p.Name == player.Name);
                if (int.Parse(writedPlayer.Score) < int.Parse(player.Score))
                    writedPlayer.Score = player.Score;
            }
            else
                players.Add(player);

            JsonFileManager.WriteToJsonFile(jsonPath, players);
        }
    }
}
