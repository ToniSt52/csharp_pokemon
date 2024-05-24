using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_on_Console
{
    class Moves
    {
        // Method to return the set tuple of a move
        public static Tuple<int, int, string> Get_move_tuple(string move)
        {
            Dictionary<string, Tuple<int, int, string>> moves = new Dictionary<string, Tuple<int, int, string>>()
            {
                /*Dictionary<string, Tuple<int, int, string>> moves = new Dictionary<string, Tuple<int, int, string>>();
                moves.Add("Tackle", new Tuple<int, int, string>(40, 100, "Normal"));*/
                // (power, accuracy, type)
                {"tackle", new Tuple<int, int, string>(40,100,"normal")},
                {"hyper beam", new Tuple<int, int, string>(150, 90, "normal")},
                {"tri attack", new Tuple<int, int, string>(80, 100, "normal")},
                {"double slap", new Tuple<int, int, string>(15, 85, "normal")},
                {"flamethrower", new Tuple<int, int, string>(90, 100, "fire")},
                {"hydro pump", new Tuple<int, int, string>(110, 80, "water")},
                {"solar beam", new Tuple<int, int, string>(120, 100, "grass")},
                {"thunder", new Tuple<int, int, string>(120,70,"electric")},
                {"ice beam", new Tuple<int, int, string>(90, 100, "ice")},
                {"dynamic punch", new Tuple<int, int, string>(100, 50, "fighting")},
                {"sludge bomb", new Tuple<int, int, string>(90, 100, "poison")},
                {"earthquake", new Tuple<int, int, string>(100, 100, "ground")},
                {"air slash", new Tuple<int, int, string>(75, 95, "flying")},
                {"psychic", new Tuple<int, int, string>(65, 100, "psychic")},
                {"x scissor", new Tuple<int, int, string>(80, 100, "bug")},
                {"rock slide", new Tuple<int, int, string>(75, 90, "rock")},
                {"shadow ball", new Tuple<int, int, string>(80, 100, "ghost")},
                {"dragon pulse", new Tuple<int, int, string>(85, 100, "dragon")},
                {"dark pulse", new Tuple<int, int, string>(80, 100, "dark")},
                {"flash cannon", new Tuple<int, int, string>(80, 100, "steel")},
                {"moonblast", new Tuple<int, int, string>(95, 100, "fairy")}
            };
            //return the tuple, that can be used later
            return moves[move];
        }
        


        //string[] available_moves = {"null", "tackle", "scratch", "pound", "water gun", "leafstorm", "thunder"};



        // old code
        //public string name_of_move;
        //public int power_of_move;
        //public string type_of_move;
        //public int number_of_move;

        //public Moves(string move_name, int move_power, string move_type, int move_no)
        //{
        //    name_of_move = move_name;
        //    power_of_move = move_power;
        //    type_of_move = move_type;
        //    number_of_move = move_no;
        //}
    }
}
