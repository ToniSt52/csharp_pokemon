using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_on_Console
{
    class Execution
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();
            //Pokemon are set up by constructors here: (string name, int level, int dex no., [types])
            //name objects with numbers, so rng is easy and no list/array is neededc
            Pokemon none = new Pokemon("none", 0, 0, 0, 0);
            Pokemon Basis = new Pokemon("Basis", 0, 0, 0, 0);
            Pokemon Rattfratz = new Pokemon("Rattfratz", 5, 19, 1, 0);
            Pokemon Glumanda = new Pokemon("Glumanda", 5, 4, 2, 0);
            Pokemon Schiggy = new Pokemon("Schiggy", 5, 7, input_type1: 3, input_type2: 0);
            Pokemon Bisasam = new Pokemon("Bisasam", 5, 1, input_type1: 4, input_type2: 8);
            Pokemon Mewtwo = new Pokemon("Mewtwo", 70, 151, 11, 0);

            // array needed for rng and random choosing of foe
            Pokemon[] array_of_object_pokemon = { none, Rattfratz, Bisasam, Schiggy, Glumanda, Mewtwo};
            Pokemon teamMember1 = Bisasam.DeepClone();
            Pokemon teamMember2 = Basis.integrate_caught_pokemon(Schiggy);
            Pokemon teamMember3 = Basis.integrate_caught_pokemon(Mewtwo);
            Pokemon[] trainer_team_array = { teamMember1, teamMember2, teamMember3, none, none, none};
            //Pokemon are all set up by constructors above
            
            Pokemon Trainer_mon = trainer_team_array[0];
            Pokemon Foe_mon = array_of_object_pokemon[rnd.Next(1,5)];

            Basis.easy_print(Trainer_mon, Foe_mon);

            //Trainer_mon.print_choose();
            bool k = true;
            bool i = true;
            do
            {
                Basis.calc_order_and_exec_atks(Foe_mon, Trainer_mon);
                Basis.easy_print(Trainer_mon, Foe_mon);
                i = Basis.end_battle(Trainer_mon, Foe_mon);
                if (Foe_mon.check_for_life() == false)
                {
                    Foe_mon.reset_to_full_life();
                    Trainer_mon.add_xp(Foe_mon);
                    Foe_mon = array_of_object_pokemon[rnd.Next(1, 5)];

                    Basis.easy_print(Trainer_mon, Foe_mon);
                }
                if (i == false)
                {
                    Trainer_mon = Basis.switch_pokemon(Trainer_mon, trainer_team_array);
                    Basis.easy_print(Trainer_mon, Foe_mon);
                    k = Trainer_mon.check_for_life();
                }
                else
                {
                    //Basis.easy_print(Trainer_mon, Foe_mon);

                }
            }
            while (k);
            Basis.end_battle(Trainer_mon,Foe_mon);
            //Basis.switch_pokemon(teamMember1,trainer_team_array);










            // "Debugging"
            //Console.WriteLine("Name: " + array_of_object_pokemon[1].name_of_pokemon);
            //Console.WriteLine("Effectiveness of flying type to Bisasam: " + Bisasam.Type_advantage_damage_multiplier("flying", Bisasam.firstType, Bisasam.secondType));
            //Console.WriteLine("Effectiveness of electric type to Garados: " + Bisasam.Type_advantage_damage_multiplier("electric", Garados.firstType, Garados.secondType));
            //Console.WriteLine($"Level of Garados is: {Garados.Full_damage_calculation(Garados)}");
            //Console.WriteLine("Types: " + Bisasam.type_Combo);

            //Console.WriteLine($"Dex_entry before: {Bisasam.Dex_entry}");
            //Bisasam.Dex_entry = 12;
            //Console.WriteLine($"Dex_entry after: {Bisasam.Dex_entry}");
            //string attacking_move = "thunder";
            //Tuple<int, int, string> temp_move_vals = Moves.Get_move_tuple(attacking_move);
            //Console.WriteLine($"Damage from Bisasam to Garados using {attacking_move} is: {Bisasam.Full_damage_calculation(temp_move_vals, Bisasam, Garados)}");
            //string temp_move_type = temp_move_vals.Item3;
            //Console.WriteLine(temp_move_type);
            //Console.WriteLine("Effectiveness of electric type to Garados: " + Bisasam.Type_advantage_damage_multiplier(temp_move_type, Garados));
            // End of "Debugging"


            /* 
               Left over implementations:
             - Level System
             - HP System
             - Movesets
             - 
           */
        }
    }
}
