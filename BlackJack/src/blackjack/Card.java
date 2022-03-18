/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package blackjack;


public class Card {
   protected final int value;
   protected final int rank;
   protected final int suit;
//copy constructor GUI
    public Card(Card c) {
        this.rank=c.rank;
        this.suit = c.suit;
        this.value = c.value;
    }

    public Card(int value, int rank, int suit) {
        this.value = value;
        this.rank = rank;
        this.suit = suit;
    }

  
   

    public int getValue() {
        return value;
    }

   
    public int getRank() {
        return rank;
    }

    

    public int getSuit() {
        return suit;
    }

   
   
   
    
}
