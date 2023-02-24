using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace code_name_board_game.Controllers
{
    public class CardController
    {
        public IList<Card> omenCards;
        public IList<Card> eventCards;
        public IList<Card> itemCards;

        /// <summary>
        /// The CardController takes the lists for the different types of cards that are created in externalData.cs and randomises them.
        /// </summary>
        /// <param name="omencardlist">A list made up of card objects - omen cards</param>
        /// <param name="itemcardlist">A list made up of card objects - item cards</param>
        /// <param name="eventcardlist">A list made up of card objects - event cards</param>
        public CardController(IList<Card>omencardlist, IList<Card> itemcardlist, IList<Card> eventcardlist)
        {
            var rnd = new Random();
            omenCards = omencardlist.OrderBy(card => rnd.Next()).ToList();
            eventCards = eventcardlist.OrderBy(card => rnd.Next()).ToList();
            itemCards = itemcardlist.OrderBy(card => rnd.Next()).ToList();

            Debug.WriteLine("Check for shuffling////////////////////////////////////////////////");
            foreach (var card in omenCards)
            {
                
                Debug.WriteLine("{0} - {1}", card.name, card.description);
            }
            foreach (var card in eventCards)
            {

                Debug.WriteLine("{0} - {1}", card.name, card.description);
            }
            foreach (var card in itemCards)
            {

                Debug.WriteLine("{0} - {1}", card.name, card.description);
            }
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}