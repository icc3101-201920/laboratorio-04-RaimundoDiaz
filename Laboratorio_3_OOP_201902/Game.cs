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
        private List<Deck> cards;
        private int numberOfDeck;

        //Constructor
        public Game()
        {
            decks = new List<Deck>();
            cards = new List<Deck>();

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
        public void Read()
        {
            string s = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Files/Decks.txt");
            StreamReader reader = new StreamReader(s);

            string start = reader.ReadLine();
            numberOfDeck = 0;
            while (!reader.EndOfStream)
            {
                if (start == "START")
                {
                    
                    string line = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        if (line == "END")
                        {
                            decks[numberOfDeck].Cards = new List<Card>(cards);
                            numberOfDeck += 1;
                            break;
                        }
                        string[] cardParams = line.Split(',');
                        switch (cardParams[0])
                        {
                            case "CombatCard":
                                cards.Add(new CombatCard( cardParams[1],
                                    ((Enums.EnumType)Enum.Parse(typeof(Enums.EnumType), cardParams[2]))).ToString(),
                                    cardParams[3].ToString(), Convert.ToInt32(cardParams[4]), Boolean.Parse(cardParams[5]));
                                break;                              //NO SE PORQUE AMBOS ME DICEN QUE EL PARAMETRO QUE METO EN EFFECT
                                                                    //NO ES DEL TIPO NECESARIO SIENDO QUE EFFECT ES STRING.
                            case "SpecialCard":
                                cards.Add(new SpecialCard(cardParams[1],
                                    (Enums.EnumType)Enum.Parse(typeof(Enums.EnumType),
                                    cardParams[2])), cardParams[3]);
                                break;
                        }

                    }

                }
                else
                {
                    throw new IndexOutOfRangeException($"Wrong action {start}, please enter START to start a deck");
                }
            }
            reader.Close();

        }
    }
}
