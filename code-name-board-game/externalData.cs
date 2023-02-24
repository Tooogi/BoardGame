using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Text.Json;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace code_name_board_game
{
    public static class ExternalData
    {

        private const string characterPath = "character.json";
        private const string cellPositionPath = "cells.json";
        private const string OmenCardFilePath = "omen-cards.json";
        private const string ItemCardFilePath = "item-cards.json";
        private const string EventCardFilePath = "event-cards.json";

            public static IList<Player> LoadCharacters()
        {
            var characters = File.ReadAllText(characterPath);
            var characterList = JsonSerializer.Deserialize<IList<Player>>(characters);

            foreach (var players in characterList)
            {
                Debug.WriteLine(players.Name);
            }

            return characterList;
        }

        public static IList<Cell> LoadCellPositions()
        {
            if (File.Exists(cellPositionPath))
            {
                {
                    var cells = File.ReadAllText(cellPositionPath);
                    var cellList = JsonSerializer.Deserialize<IList<Cell>>(cells);

                    foreach (var cell in cellList)
                    {
                        Debug.WriteLine("{0}.{1}", cell.X, cell.Y);
                    }

                    return cellList;
                }
            }
            else
            {
                throw new FileNotFoundException(@"[cells.json not in directory]");
            }
        }

       /*  public static IList<Card> LoadOmenCards()
        {
            if (File.Exists(OmenCardFilePath))
            {
                {
                    var cards = File.ReadAllText(OmenCardFilePath);
                    var cardList = JsonSerializer.Deserialize<IList<Card>>(cards);

                    foreach (var card in cardList)
                    {
                        Debug.WriteLine("{0} - {1}", card.name, card.description);
                    }

                    return cardList;
                }
            }
            else
            {
                throw new FileNotFoundException(@"[omen-cards.json not in directory]");
            }
        } */
        public static IList<Card> LoadItemCards()
        {
            if (File.Exists(ItemCardFilePath))
            {
                {
                    var cards = File.ReadAllText(ItemCardFilePath);
                    var cardList = JsonSerializer.Deserialize<IList<Card>>(cards);

                    foreach (var card in cardList)
                    {
                        Debug.WriteLine("{0} - {1}", card.name, card.description);
                    }

                    return cardList;
                }
            }
            else
            {
                throw new FileNotFoundException(@"[item-cards.json not in directory]");
            }
        }

        public static IList<Card> LoadEventCards()
        {
            if (File.Exists(EventCardFilePath))
            {
                {
                    var cards = File.ReadAllText(EventCardFilePath);
                    var cardList = JsonSerializer.Deserialize<IList<Card>>(cards);

                    foreach (var card in cardList)
                    {
                        Debug.WriteLine("{0} - {1}", card.name, card.description);
                    }

                    return cardList;
                }
            }
            else
            {
                throw new FileNotFoundException(@"[event-cards.json not in directory]");
            }
        }
    }
}