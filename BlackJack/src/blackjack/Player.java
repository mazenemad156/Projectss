
package blackjack;


public class Player {
    protected String Name;
    protected int Score=0;
    int numofcard=0;
    boolean b , f;
    //for every player 11 card
    Card c[] = new Card[11];
    

    public void setName(String Name) {
        this.Name = Name;
    }

    public void setScore(int Score) {
        this.Score = Score;
    }

    public void setCard(Card[] card) {
        this.c = card;
    }
    
    

    public String getName() {
        return Name;
    }

    public int getScore() {
        return Score;
    }

    public Card[] getCard() {
        return c;
    }
    
    void calcScore()
    {   Score=0;
        for (int i = 0; i < numofcard; i++) {
            this.Score+=c[i].value;
            
        }
    
    }
    
}