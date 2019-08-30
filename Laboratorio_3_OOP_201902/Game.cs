using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;

        //Constructor
        public Game()
        {

        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }
        public void read()
        {
            string s = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Files/Decks.txt");
            StreamReader reader = new StreamReader(s);
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != "START")
                {
                    Console.WriteLine($"Wrong action {line}, please enter START to start a deck");
                    break;

                }
                while (!reader.EndOfStream)
                {
                    if (line == "END")
                    {
                        break;
                    }
                    string[] cardParams = line.Split(',');
                    switch (cardParams[0])
                    {
                        case "CombatCard":

                            break;
                        case "SpecialCard":

                            break;
                    }

                }
            }
            
            reader.Close();

        }
    }
}
