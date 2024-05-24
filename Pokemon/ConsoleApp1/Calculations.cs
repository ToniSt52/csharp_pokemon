using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_on_Console
{
    class Calculations
    {
        ////Random rnd = new Random();
        //// init instance of Pokemon to get values
        ////protected Pokemon _Get_Pokemon_values;
        ////public Calculations(Pokemon Pokemon)
        ////{
        ////    _Get_Pokemon_values = Pokemon;
        ////}
        //// exchange strings for pokemon objects later
        //private double Type_advantage_damage_multiplier(string attacking_type ,Pokemon object_of_defending_Pokemon)
        //{
        //    // extract type values
        //    //string attacking_type = object_of_attacking_Move.type_of_move;
        //    string first_defending_type = object_of_defending_Pokemon.firstType;
        //    string second_defending_type = object_of_defending_Pokemon.secondType;

        //    // new approach, tiedied up by copilot
        //    Dictionary<string, Dictionary<string, double>> typeAdvantages = new Dictionary<string, Dictionary<string, double>>()
        //    {
        //        // Add all of the type effectiveness factors here:
        //        // {"attacking type", {"defending type", <<effectiveness>>}}
        //        {"normal", new Dictionary<string, double> {{"rock", 0.5}, {"ghost", 0}, {"steel", 0.5}}},
        //        {"fire", new Dictionary<string, double> {{"grass", 2}, {"ice", 2}, {"bug", 2}, {"steel", 2}, {"fire", 0.5}, {"water", 0.5}, {"rock", 0.5}, {"dragon", 0.5}}},
        //        {"water", new Dictionary<string, double> {{"fire", 2}, {"ground", 2}, {"rock", 2}, {"water", 0.5}, {"grass", 0.5}, {"dragon", 0.5}}},
        //        {"grass", new Dictionary<string, double> {{"fire", 0.5}, {"water", 2}, {"grass", 0.5}, {"poison", 0.5}, {"ground", 2}, {"flying", 0.5}, {"bug", 0.5}, {"rock", 2}, {"dragon", 0.5}, {"steel", 0.5}}},
        //        {"electric", new Dictionary<string, double> {{"water", 2}, {"grass", 0.5}, {"electric", 0.5}, {"ground", 0}, {"flying", 2 }, {"dragon", 0.5}}},
        //        {"ice", new Dictionary<string, double> {{"fire", 0.5}, {"water", 0.5}, {"grass", 2}, {"ice", 0.5}, {"ground", 2}, {"flying", 2}, {"dragon", 2}, {"steel", 0.5}}},
        //        {"fighting", new Dictionary<string, double> {{"normal", 2}, {"ice", 2}, {"rock", 2}, {"dark", 2}, {"steel", 2}, {"bug", 0.5}, {"flying", 0.5}, {"poison", 0.5}, {"fairy", 0.5}, {"psychic", 0.5}, {"ghost", 0}}},
        //        {"poison", new Dictionary<string, double> {{"grass", 2}, {"fairy", 2}, {"bug", 2}, {"fighting", 2}, {"poison", 0.5}, {"ground", 0.5}, {"rock", 0.5}, {"ghost", 0.5}, {"steel", 0}}},
        //        {"ground", new Dictionary<string, double> {{"fire", 2}, {"electric", 2}, {"poison", 2}, {"rock", 2}, {"steel", 2}, {"grass", 0.5}, {"bug", 0.5}}},
        //        {"flying", new Dictionary<string, double> {{"grass", 2}, {"fighting", 2}, {"bug", 2}, {"electric", 0.5}, {"rock", 0.5}, {"steel", 0.5}}},
        //        {"psychic", new Dictionary<string, double> {{"fighting", 2}, {"poison", 2}, {"psychic", 0.5}, {"steel", 0.5}}},
        //        {"bug", new Dictionary<string, double> {{"grass", 2}, {"psychic", 2}, {"dark", 2}, {"fire", 0.5}, {"fighting", 0.5}, {"poison", 0.5}, {"flying", 0.5}, {"ghost", 0.5}, {"steel", 0.5}, {"fairy", 0.5}}},
        //        {"rock", new Dictionary<string, double> {{"fire", 2}, {"ice", 2}, {"flying", 2}, {"bug", 2}, {"fighting", 0.5}, {"ground", 0.5}, {"steel", 0.5}}},
        //        {"ghost", new Dictionary<string, double> {{"psychic", 2}, {"ghost", 2}, {"dark", 0.5}, {"normal", 0}}},
        //        {"dragon", new Dictionary<string, double> {{"dragon", 2}, {"steel", 0.5}, {"fairy", 0}}},
        //        {"dark", new Dictionary<string, double> {{"psychic", 2}, {"ghost", 2}, {"fighting", 0.5}, {"dark", 0.5}, {"fairy", 0.5}}},
        //        {"steel", new Dictionary<string, double> {{"ice", 2}, {"rock", 2}, {"fairy", 2}, {"fire", 0.5}, {"water", 0.5}, {"electric", 0.5}, {"steel", 0.5}}},
        //        {"fairy", new Dictionary<string, double> {{"fighting", 2}, {"dragon", 2}, {"dark", 2}, {"fire", 0.5}, {"poison", 0.5}, {"steel", 0.5}}}
        //    };

        //    string[] defending_type_array = { first_defending_type, second_defending_type };
        //    double[] type_multipliers_array = { 1, 1 }; // Initialize to 1 because it's a multiplier

        //    for (int i = 0; i < 2; i++)
        //    {
        //        if (typeAdvantages[attacking_type].ContainsKey(defending_type_array[i]))
        //        {
        //            type_multipliers_array[i] = typeAdvantages[attacking_type][defending_type_array[i]];
        //        }
        //    }

        //    double damage_Multiplier = type_multipliers_array[0] * type_multipliers_array[1];
        //    return damage_Multiplier;
        //}

        //// method for calculating all damage of an attack, based on: Level, Crit-chance, Move-Power, STAB, type advantage, random roll
        //public int Full_damage_calculation(Tuple<int, int, string> attacking_move, Pokemon object_of_attacking_Pokemon, Pokemon object_of_defending_Pokemon)
        //{
        //    double level_of_attacking_pokemon = object_of_attacking_Pokemon.level;
        //    double power_of_attack = attacking_move.Item1;
        //    double STAB = 1;
        //    if (attacking_move.Item3 == object_of_attacking_Pokemon.firstType || attacking_move.Item3 == object_of_attacking_Pokemon.secondType)
        //    {
        //        STAB = 1.5;
        //    }
        //    else
        //    {
        //        STAB = 1;
        //    }

        //    // rng for crit and rnd_roll
        //    double Crit_roll = 1;
        //    if (rnd.Next(1,8) == 1)
        //    {
        //        Crit_roll = 2;
        //    }
        //    else
        //    {
        //        Crit_roll = 1;
        //    }
        //    //Console.WriteLine($"Crit multiplier = {Crit_roll}");
        //    double random_roll = rnd.Next(217, 255) / 255.0;
        //    //Console.WriteLine($"random multiplier = {random_roll}");
        //    // end of rnd calc  

        //    double damage_output_double = (((2 * level_of_attacking_pokemon * Crit_roll / 5) * power_of_attack * 1) / (50) + 2) * STAB * Type_advantage_damage_multiplier(attacking_move.Item3, object_of_defending_Pokemon) * random_roll;
        //    //int damage_output = 0;
        //    //return level_of_attacking_pokemon;
        //    //Console.WriteLine($"damage double = {damage_output_double}");
        //    int damage_output_int = (int)Math.Round(damage_output_double);
        //    return damage_output_int;
        //}

        // my old version
        //double first_type_multiplier = 1;
        //double second_type_multiplier = 1;

        //public double Type_advantage_damage_multiplier(string attacking_type, string first_defending_type, string second_defending_type)
        //{
        //    //int int_Damage = 0;
        //    string[] defending_type_array = { first_defending_type, second_defending_type };
        //    double[] type_multipliers_array = { first_type_multiplier, second_type_multiplier };

        //    for (int i = 0; i < 2; i++) // start of for loop to loop damage multipliers
        //    {
        //        // normal weak to ...
        //        if (attacking_type == Pokemon.types[1] && (defending_type_array[i] == Pokemon.types[13] || defending_type_array[i] == Pokemon.types[17]))
        //        {
        //            type_multipliers_array[i] = 0.5;
        //        }
        //        // normal immune on ...
        //        else if (attacking_type == Pokemon.types[1] && defending_type_array[i] == Pokemon.types[14])
        //        {
        //            type_multipliers_array[i] = 0;
        //        }
        //        //fire effective to ...
        //        else if (attacking_type == Pokemon.types[2] && (defending_type_array[i] == Pokemon.types[4] || defending_type_array[i] == Pokemon.types[6] || defending_type_array[i] == Pokemon.types[12] || defending_type_array[i] == Pokemon.types[17]))
        //        {
        //            type_multipliers_array[i] = 2;
        //        }
        //        // fire weak to ...
        //        else if (attacking_type == Pokemon.types[2] && (defending_type_array[i] == Pokemon.types[2] || defending_type_array[i] == Pokemon.types[3] || defending_type_array[i] == Pokemon.types[13] || defending_type_array[i] == Pokemon.types[15]))
        //        {
        //            type_multipliers_array[i] = 0.5;
        //        }
        //        // water effective to ...
        //        else if (attacking_type == Pokemon.types[3] && (defending_type_array[i] == Pokemon.types[2] || defending_type_array[i] == Pokemon.types[9] || defending_type_array[i] == Pokemon.types[13]))
        //        {
        //            type_multipliers_array[i] = 2;
        //        }
        //        // water weak to ...
        //        else if (attacking_type == Pokemon.types[3] && (defending_type_array[i] == Pokemon.types[3] || defending_type_array[i] == Pokemon.types[4] || defending_type_array[i] == Pokemon.types[15]))
        //        {
        //            type_multipliers_array[i] = 0.5;
        //        }
        //        // grass effective to .. 

        //    } // end of for loop

        //    double damage_Multiplier = type_multipliers_array[0] * type_multipliers_array[1];
        //    return damage_Multiplier;
        //}
        ////Damage multiplier due to type (dis-)advantage

    }
}
