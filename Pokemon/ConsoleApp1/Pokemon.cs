using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_on_Console
{
    class Pokemon
    {
        Random rnd = new Random();

        private int level;
        private string firstType { get; }
        private string secondType { get; }
        private int int_firstType;
        private int int_secondType;
        private string name_of_pokemon { get; }
        private static string[] types = { "null", "normal", "fire", "water", "grass", "electric", "ice", "fighting", "poison", "ground", "flying", "psychic", "bug", "rock", "ghost", "dragon", "dark", "steel", "fairy" };
        private string type_Combo;
        private int Dex_entry;

        private int current_hp;
        private int max_hp;
        private int atk_stat;
        private int def_stat;
        private int init_stat;
        private int current_exp_count;
        private int exp_to_lvl_up;
        private string[] moveset;

        public Pokemon(string input_pokemon_name, int input_current_Level, int input_pokeDex_No, int input_type1, int input_type2) /*: base(null)*/
        {
            name_of_pokemon = input_pokemon_name;
            level = input_current_Level;
            Dex_entry = input_pokeDex_No;
            firstType = types[input_type1];
            secondType = types[input_type2];
            int_firstType = input_type1;
            int_secondType = input_type2;
            type_Combo = firstType + " & " + secondType;
            set_values();
            
            

            //_Get_Pokemon_values = this;
            /* 
             * Moveset
             * HP
             * 
            */
        }

        //didn'T work
        //public Pokemon[] FullSetup()
        //{
        //    Pokemon none = new Pokemon("none", 0, 0, 0, 0);
        //    Pokemon Basis = new Pokemon("Basis", 0, 0, 0, 0);
        //    Pokemon Rattfratz = new Pokemon("Rattfratz", 5, 19, 1, 0);
        //    Pokemon Glumanda = new Pokemon("Glumanda", 5, 4, 2, 0);
        //    Pokemon Schiggy = new Pokemon("Schiggy", 5, 7, input_type1: 3, input_type2: 0);
        //    Pokemon Bisasam = new Pokemon("Bisasam", 5, 1, input_type1: 4, input_type2: 8);
        //    Pokemon Mewtwo = new Pokemon("Mewtwo", 5, 151, 11, 0);

        //    Pokemon[] array_of_object_pokemon = { none, Rattfratz, Bisasam, Schiggy, Glumanda, Mewtwo };

        //    return array_of_object_pokemon;
        //}

        public Pokemon DeepClone()
        {
            Pokemon clone = new Pokemon(this.name_of_pokemon, this.level, this.Dex_entry, this.int_firstType , this.int_secondType);

            return clone;
        }

        public Pokemon integrate_caught_pokemon(Pokemon caught_pokemon)
        {
            Pokemon next_member = caught_pokemon.DeepClone();
            return next_member;
        }

        public void add_xp(Pokemon foe_mon) // this = eigenes pokemon
        {
            int exp = (int)(((100 * foe_mon.getLevel()) / 5) * (Math.Pow(2 * foe_mon.getLevel() + 10, 2.5)) / (Math.Pow(this.level + foe_mon.getLevel() + 10, 2.5)) + 1);
            this.current_exp_count += exp;
            Console.WriteLine($"{this.name_of_pokemon} gains {exp} XP");
            while (this.current_exp_count >= this.exp_to_lvl_up)
            {
                this.level += 1;
                this.current_exp_count -= this.exp_to_lvl_up;
            }
        }

        public int getLevel()
        {
            return this.level;
        }

        public void reset_to_full_life()
        {
            this.current_hp = this.max_hp;
        }

        public void set_values()
        {
            // iterate stats based on level rnd.Next(0,3) * level
            this.max_hp = rnd.Next(8, 12);
                this.atk_stat = rnd.Next(4, 8);
                this.def_stat = rnd.Next(4, 8);
                this.init_stat = rnd.Next(6, 10);
                this.current_exp_count = 0;
                this.exp_to_lvl_up = (int)Math.Pow(this.level, 3) - (int)Math.Pow(this.level - 1, 3);
                this.moveset = choose_moveset();
                
            for (int i = 0; i < this.level; i++)
            {
                this.max_hp += rnd.Next(1, 4);
                this.atk_stat += rnd.Next(0, 3);
                this.def_stat += rnd.Next(0, 3);
                this.init_stat += rnd.Next(1, 4);
                Thread.Sleep(2);
            }
                this.current_hp = max_hp;
            //Console.WriteLine($"{this.name_of_pokemon}: hp = {this.max_hp}");
            //Console.WriteLine($"{this.name_of_pokemon}: init = {this.level}");
            //Console.WriteLine($"{this.name_of_pokemon}: init = {this.atk_stat}");
            //Console.WriteLine($"{this.name_of_pokemon}: init = {this.def_stat}");
            //Console.WriteLine($"{this.name_of_pokemon}: init = {this.init_stat}");
        }

        public void print_Pokemon_values()
        {
            Console.WriteLine($"\t\t\t\t\t{this.name_of_pokemon}\t LVL: {this.level}");
            //Console.WriteLine();
            print_healthbar("HP ", this.current_hp, this.max_hp);
            Console.WriteLine($" {current_hp}/{max_hp}");
            Console.WriteLine();
            print_exp_bar("EXP", current_exp_count, exp_to_lvl_up);
            //Console.WriteLine($"{current_exp_count}/{exp_to_lvl_up}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        public Pokemon switch_pokemon(Pokemon active_pokemon, Pokemon[] trainerTeam)
        {
            bool check_for_feasability = true;
            Console.WriteLine("Which Pokemon do you want to send in to battle?");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\t{i + 1}. {trainerTeam[i].name_of_pokemon}");
            }
            Console.WriteLine("\t7. cancel");
            Console.WriteLine("\t8. give up");


            int chosenNumber = 1;
            while (check_for_feasability == true)
            {
                Console.WriteLine("Please choose a member from 1 to 6 or cancel");
                chosenNumber = (Convert.ToInt32(Console.ReadLine()) - 1);

                if (chosenNumber == 6)
                {
                    //active_pokemon = trainerTeam[chosenNumber];

                    if (active_pokemon.current_hp > 0) //check if pokemon is alive
                    {
                        Console.WriteLine($"{active_pokemon.name_of_pokemon} will stay in battle.");
                        check_for_feasability = false;
                    }
                    else //when dead
                    {
                        Console.WriteLine($"{active_pokemon.name_of_pokemon} cannot fight anymore. Please choose another pokemon or give up!");
                        //check_for_feasability = false;
                    }
                }
                else if (chosenNumber == 7)
                {
                    Console.WriteLine("You gave up!");
                    check_for_feasability = false;
                }
                else if (active_pokemon == trainerTeam[chosenNumber])
                {
                    Console.WriteLine("Pokemon is already in battle! Please Choose another one.");
                }
                else if (chosenNumber < 0)
                {
                    Console.WriteLine("Invalid Input, please try again!");
                }
                else if (chosenNumber > 7)
                {
                    Console.WriteLine("Invalid Input, please try again!");
                }
                else
                {
                    active_pokemon = trainerTeam[chosenNumber];
                    if (active_pokemon.current_hp > 0) //check if pokemon is alive
                    {
                        Console.WriteLine($"{active_pokemon.name_of_pokemon} is sent in to battle!");
                        check_for_feasability = false;
                    }
                    else
                    {
                        Console.WriteLine($"{active_pokemon.name_of_pokemon} cannot fight anymore. Please chosse another pokemon or give up!");
                    }

                }
            }
            Pokemon pokemonSentOut = active_pokemon;
            return pokemonSentOut;
        }

        public bool check_trainer_hp()
        {
            if (this.current_hp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void easy_print(Pokemon object_of_trainer_Pokemon, Pokemon object_of_foe_Pokemon)
        {
            object_of_foe_Pokemon.print_Pokemon_values();
            object_of_trainer_Pokemon.print_Pokemon_values();
        }

        public bool check_for_life()
        {
            if (this.current_hp == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool end_battle(Pokemon object_of_trainer_Pokemon, Pokemon object_of_foe_Pokemon)
        {
            if (object_of_trainer_Pokemon.check_for_life() == false)
            {
                Console.WriteLine("YOU LOST!");
                //this.switch_pokemon(object_of_trainer_Pokemon, );
                return this.game_over();
            }
            else if (object_of_foe_Pokemon.check_for_life() == false)
            {
                Console.WriteLine("CONGRATS! YOU WON!");
                return this.game_over();
            }
            else
            {
                return true;

            }
        }

        public bool game_over()
        {
            return false;
        }

        public string print_choose_and_return_move()
        {
            Console.WriteLine();
            Console.WriteLine($"What will {this.name_of_pokemon} do?");
            Console.WriteLine($"\t1. {this.moveset[0]} \n\t2. {this.moveset[1]} \n\t3. {this.moveset[2]} \n\t4. {moveset[3]}");
            int chosen_move = Convert.ToInt32(Console.ReadLine()) - 1;

            bool i = true;
            while (i)
            {

                if (chosen_move < 0)
                {
                    Console.WriteLine("Please chosse a move from 1-4.");
                    chosen_move = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                else if (chosen_move > 3)
                {
                    Console.WriteLine("Please chosse a move from 1-4.");
                    chosen_move = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                else
                {
                    i = false;
                }
            }
            return this.moveset[chosen_move];
            
        }

        public void calc_order_and_exec_atks(Pokemon object_of_foe_Pokemon, Pokemon object_of_trainer_Pokemon)
        {
            bool loop_once = true;
            if (object_of_trainer_Pokemon.init_stat > object_of_foe_Pokemon.init_stat)
            {
                string chosen_move = object_of_trainer_Pokemon.print_choose_and_return_move();
                this.trainer_on_foe(chosen_move, object_of_foe_Pokemon, object_of_trainer_Pokemon);
                while (this.end_battle(object_of_trainer_Pokemon, object_of_foe_Pokemon) && loop_once)
                {
                    this.foe_on_trainer(object_of_foe_Pokemon, object_of_trainer_Pokemon);
                    loop_once = false;
                }
            }
            else if (object_of_trainer_Pokemon.init_stat < object_of_foe_Pokemon.init_stat)
            {
                string chosen_move = object_of_trainer_Pokemon.print_choose_and_return_move();
                this.foe_on_trainer(object_of_foe_Pokemon, object_of_trainer_Pokemon);
                while (this.end_battle(object_of_trainer_Pokemon, object_of_foe_Pokemon) && loop_once)
                {
                    this.trainer_on_foe(chosen_move, object_of_foe_Pokemon, object_of_trainer_Pokemon);
                    loop_once = false;
                }
            }
            else
            {
                if (rnd.Next(1,2) == 1)
                {
                    string chosen_move = object_of_trainer_Pokemon.print_choose_and_return_move();
                    this.trainer_on_foe(chosen_move, object_of_foe_Pokemon, object_of_trainer_Pokemon);
                    while (this.end_battle(object_of_trainer_Pokemon, object_of_foe_Pokemon) && loop_once)
                    {
                        this.foe_on_trainer(object_of_foe_Pokemon, object_of_trainer_Pokemon);
                        loop_once = false;
                    }
                }
                else
                {
                    string chosen_move = object_of_trainer_Pokemon.print_choose_and_return_move();
                    this.foe_on_trainer(object_of_foe_Pokemon, object_of_trainer_Pokemon);
                    while (this.end_battle(object_of_trainer_Pokemon, object_of_foe_Pokemon) && loop_once)
                    {
                        this.trainer_on_foe(chosen_move, object_of_foe_Pokemon, object_of_trainer_Pokemon);
                        loop_once = false;
                    }
                }
            }
        }

        public void foe_on_trainer(Pokemon object_of_foe_Pokemon, Pokemon object_of_trainer_Pokemon)
        {
            string move_foe_on_trainer = object_of_foe_Pokemon.moveset[rnd.Next(0, 3)];
            object_of_foe_Pokemon.execute_attack_and_reduce_hp(move_foe_on_trainer, object_of_foe_Pokemon, object_of_trainer_Pokemon);
        }

        public void trainer_on_foe(string chosen_move, Pokemon object_of_foe_Pokemon, Pokemon object_of_trainer_Pokemon)
        {
            string move_trainer_on_foe = chosen_move;
            object_of_trainer_Pokemon.execute_attack_and_reduce_hp(move_trainer_on_foe, object_of_trainer_Pokemon, object_of_foe_Pokemon);
        }

        public string[] choose_moveset()
        {
            string[] return_moveset = null;

            switch (this.firstType)
            {
                case "normal":
                    return_moveset = new string[] { "tackle", "hyper beam", "tri attack", "double slap" };
                    break;
                case "fire":
                    return_moveset = new string[] { "flamethrower", "solar beam", "tackle", "hyper beam" };
                    break;
                case "water":
                    return_moveset = new string[] { "hydro pump", "tackle", "ice beam", "hyper beam" };
                    break;
                case "grass":
                    return_moveset = new string[] { "solar beam", "tackle", "sludge bomb", "x scissor" };
                    break;
                case "electric":
                    return_moveset = new string[] { "thunder", "tackle", "hyper beam", "flash cannon" };
                    break;
                case "ice":
                    return_moveset = new string[] { "ice beam", "tackle", "hyper beam", "blizzard" };
                    break;
                case "fighting":
                    return_moveset = new string[] { "dynamic punch", "tackle", "hyper beam", "rock slide" };
                    break;
                case "poison":
                    return_moveset = new string[] { "sludge bomb", "tackle", "hyper beam", "shadow ball" };
                    break;
                case "ground":
                    return_moveset = new string[] { "earthquake", "tackle", "hyper beam", "rock slide" };
                    break;
                case "flying":
                    return_moveset = new string[] { "air slash", "tackle", "hyper beam", "sky attack" };
                    break;
                case "psychic":
                    return_moveset = new string[] { "air slash", "tackle", "hyper beam", "psychic" };
                    break;
                case "bug":
                    return_moveset = new string[] { "x scissor", "tackle", "hyper beam", "bug buzz" };
                    break;
                case "rock":
                    return_moveset = new string[] { "rock slide", "tackle", "hyper beam", "stone edge" };
                    break;
                case "ghost":
                    return_moveset = new string[] { "shadow ball", "tackle", "hyper beam", "shadow claw" };
                    break;
                case "dragon":
                    return_moveset = new string[] { "dragon pulse", "tackle", "hyper beam", "dragon claw" };
                    break;
                case "dark":
                    return_moveset = new string[] { "dark pulse", "tackle", "hyper beam", "night slash" };
                    break;
                case "steel":
                    return_moveset = new string[] { "flash cannon", "tackle", "hyper beam", "meteor mash" };
                    break;
                case "fairy":
                    return_moveset = new string[] { "moonblast", "tackle", "hyper beam", "dazzling gleam" };
                    break;
                default:
                    return_moveset = new string[] { }; // Or some default moves
                    break;
            }
            return return_moveset;
        }


        public void execute_attack_and_reduce_hp(string attacking_move, Pokemon object_of_attacking_Pokemon, Pokemon object_of_defending_Pokemon)
        {
            Tuple<int, int, string> temp_move_vals = Moves.Get_move_tuple(attacking_move);
            Console.WriteLine($"{object_of_attacking_Pokemon.name_of_pokemon} uses {attacking_move} on {object_of_defending_Pokemon.name_of_pokemon}");
            int damage_done = Full_damage_calculation(temp_move_vals, object_of_attacking_Pokemon, object_of_defending_Pokemon);
            object_of_defending_Pokemon.current_hp = object_of_defending_Pokemon.current_hp - damage_done;
            if (object_of_defending_Pokemon.current_hp < 0)
            {
                object_of_defending_Pokemon.current_hp = 0;
            }
            //Console.WriteLine(object_of_defending_Pokemon.current_hp);
        }

        public void print_healthbar(string life, int current_hp_print, int max_hp_print)
        {
            //▓
            //░
            int current_hp_percentage = (current_hp_print * 100) / max_hp_print;
            int length_of_bar = (current_hp_percentage * 50) / 100;
            Console.Write($"{life} : ");
            if (current_hp_percentage == 0)
            {
                for (int i = 0; i <= 50; i++)
                {
                    Console.Write("░");
                }
            }
            else
            {
                for (int i = 0; i <= 50; i++)
                {
                    if (i <= length_of_bar)
                    {
                        Console.Write("▓");
                    }
                    else
                    {
                        Console.Write("░");
                    }
                }
            }
        }

        public void print_exp_bar(string experience, int current_exp_print, int max_exp_print)
        {
            //▓
            //░
            int current_exp_percentage = (current_exp_print * 100) / max_exp_print;
            int length_of_bar = (current_exp_percentage * 50) / 100;
            Console.Write($"{experience} : ");
            for (int i = 1; i <= 51; i++) /*(int i = 0; i <= 50; i++)*/
            {
                if (i <= length_of_bar) /*(i < length_of_bar)*/
                {
                    Console.Write("▓");
                }
                else
                {
                    Console.Write("░");
                }
            }
        }

     
        private double Type_advantage_damage_multiplier(string attacking_type, Pokemon object_of_defending_Pokemon)
        {
            // extract type values
            //string attacking_type = object_of_attacking_Move.type_of_move;
            string first_defending_type = object_of_defending_Pokemon.firstType;
            string second_defending_type = object_of_defending_Pokemon.secondType;

            // new approach, tiedied up by copilot
            Dictionary<string, Dictionary<string, double>> typeAdvantages = new Dictionary<string, Dictionary<string, double>>()
            {
                // Add all of the type effectiveness factors here:
                // {"attacking type", {"defending type", <<effectiveness>>}}
                {"normal", new Dictionary<string, double> {{"rock", 0.5}, {"ghost", 0}, {"steel", 0.5}}},
                {"fire", new Dictionary<string, double> {{"grass", 2}, {"ice", 2}, {"bug", 2}, {"steel", 2}, {"fire", 0.5}, {"water", 0.5}, {"rock", 0.5}, {"dragon", 0.5}}},
                {"water", new Dictionary<string, double> {{"fire", 2}, {"ground", 2}, {"rock", 2}, {"water", 0.5}, {"grass", 0.5}, {"dragon", 0.5}}},
                {"grass", new Dictionary<string, double> {{"fire", 0.5}, {"water", 2}, {"grass", 0.5}, {"poison", 0.5}, {"ground", 2}, {"flying", 0.5}, {"bug", 0.5}, {"rock", 2}, {"dragon", 0.5}, {"steel", 0.5}}},
                {"electric", new Dictionary<string, double> {{"water", 2}, {"grass", 0.5}, {"electric", 0.5}, {"ground", 0}, {"flying", 2 }, {"dragon", 0.5}}},
                {"ice", new Dictionary<string, double> {{"fire", 0.5}, {"water", 0.5}, {"grass", 2}, {"ice", 0.5}, {"ground", 2}, {"flying", 2}, {"dragon", 2}, {"steel", 0.5}}},
                {"fighting", new Dictionary<string, double> {{"normal", 2}, {"ice", 2}, {"rock", 2}, {"dark", 2}, {"steel", 2}, {"bug", 0.5}, {"flying", 0.5}, {"poison", 0.5}, {"fairy", 0.5}, {"psychic", 0.5}, {"ghost", 0}}},
                {"poison", new Dictionary<string, double> {{"grass", 2}, {"fairy", 2}, {"bug", 2}, {"fighting", 2}, {"poison", 0.5}, {"ground", 0.5}, {"rock", 0.5}, {"ghost", 0.5}, {"steel", 0}}},
                {"ground", new Dictionary<string, double> {{"fire", 2}, {"electric", 2}, {"poison", 2}, {"rock", 2}, {"steel", 2}, {"grass", 0.5}, {"bug", 0.5}}},
                {"flying", new Dictionary<string, double> {{"grass", 2}, {"fighting", 2}, {"bug", 2}, {"electric", 0.5}, {"rock", 0.5}, {"steel", 0.5}}},
                {"psychic", new Dictionary<string, double> {{"fighting", 2}, {"poison", 2}, {"psychic", 0.5}, {"steel", 0.5}}},
                {"bug", new Dictionary<string, double> {{"grass", 2}, {"psychic", 2}, {"dark", 2}, {"fire", 0.5}, {"fighting", 0.5}, {"poison", 0.5}, {"flying", 0.5}, {"ghost", 0.5}, {"steel", 0.5}, {"fairy", 0.5}}},
                {"rock", new Dictionary<string, double> {{"fire", 2}, {"ice", 2}, {"flying", 2}, {"bug", 2}, {"fighting", 0.5}, {"ground", 0.5}, {"steel", 0.5}}},
                {"ghost", new Dictionary<string, double> {{"psychic", 2}, {"ghost", 2}, {"dark", 0.5}, {"normal", 0}}},
                {"dragon", new Dictionary<string, double> {{"dragon", 2}, {"steel", 0.5}, {"fairy", 0}}},
                {"dark", new Dictionary<string, double> {{"psychic", 2}, {"ghost", 2}, {"fighting", 0.5}, {"dark", 0.5}, {"fairy", 0.5}}},
                {"steel", new Dictionary<string, double> {{"ice", 2}, {"rock", 2}, {"fairy", 2}, {"fire", 0.5}, {"water", 0.5}, {"electric", 0.5}, {"steel", 0.5}}},
                {"fairy", new Dictionary<string, double> {{"fighting", 2}, {"dragon", 2}, {"dark", 2}, {"fire", 0.5}, {"poison", 0.5}, {"steel", 0.5}}}
            };

            string[] defending_type_array = { first_defending_type, second_defending_type };
            double[] type_multipliers_array = { 1, 1 }; // Initialize to 1 because it's a multiplier

            for (int i = 0; i < 2; i++)
            {
                if (typeAdvantages[attacking_type].ContainsKey(defending_type_array[i]))
                {
                    type_multipliers_array[i] = typeAdvantages[attacking_type][defending_type_array[i]];
                }
            }

            double damage_Multiplier = type_multipliers_array[0] * type_multipliers_array[1];
            return damage_Multiplier;
        }

        // method for calculating all damage of an attack, based on: Level, Crit-chance, Move-Power, STAB, type advantage, random roll
        public int Full_damage_calculation(Tuple<int, int, string> attacking_move, Pokemon object_of_attacking_Pokemon, Pokemon object_of_defending_Pokemon)
        {
            double level_of_attacking_pokemon = object_of_attacking_Pokemon.level;
            double power_of_attack = attacking_move.Item1;
            double STAB = 1;
            if (attacking_move.Item3 == object_of_attacking_Pokemon.firstType || attacking_move.Item3 == object_of_attacking_Pokemon.secondType)
            {
                STAB = 1.5;
            }
            else
            {
                STAB = 1;
            }

            // rng for crit and rnd_roll
            double Crit_roll = 1;
            if (rnd.Next(1, 8) == 1)
            {
                Crit_roll = 2;
                Console.WriteLine("A critical hit!");
            }
            else
            {
                Crit_roll = 1;
            }
            //Console.WriteLine($"Crit multiplier = {Crit_roll}");
            double random_roll = (rnd.Next(217, 255) / 255.0);
            //Console.WriteLine($"random multiplier = {random_roll}");
            // end of rnd calc  

            double damage_output_double = (((2 * level_of_attacking_pokemon * Crit_roll / 5) * power_of_attack * (object_of_attacking_Pokemon.atk_stat/object_of_defending_Pokemon.def_stat)) / (50) + 2) * STAB * Type_advantage_damage_multiplier(attacking_move.Item3, object_of_defending_Pokemon) * random_roll;
            //int damage_output = 0;
            switch (Type_advantage_damage_multiplier(attacking_move.Item3, object_of_defending_Pokemon))
            {
                case 0.25:
                    Console.WriteLine("It\'s not very effective!");
                    break;
                case 0.5:
                    Console.WriteLine("It\'s not very effective!");
                    break;
                case 1:
                    Console.WriteLine("It\'s effective!");
                    break;
                case 2:
                    Console.WriteLine("It\'s very effective!");
                    break;
                case 4:
                    Console.WriteLine("It\'s super effective!");
                    break;
            }
            //return level_of_attacking_pokemon;
            //Console.WriteLine($"damage double = {damage_output_double}");
            int damage_output_int = (int)Math.Round(damage_output_double);
            //Console.WriteLine($"Damage is: {damage_output_int}");
            return damage_output_int;
        }

        public void full_choosing_mechanism()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("\t 1. Battle \n\t 2. Switch \n\t 3. Item \n\t 4. Run");
            int chosen_variant = Convert.ToInt32(Console.ReadLine());
        }

    }
}
