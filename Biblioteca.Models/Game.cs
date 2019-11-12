using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Game
    {
        public int id_game { get; set; }
        public string title { get; set; }
        public string cover_image { get; set; }
        public double? amount_paid { get; set; }
        public DateTime? purchase_date { get; set; }
        public int id_publisher { get; set; }
        public int id_genre { get; set; }
    }
}
