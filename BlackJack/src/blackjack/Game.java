
package blackjack;
import java.util.*;

public class Game {
    Scanner s = new Scanner(System.in);
    Player player[] = new Player[4];
    Card card[] = new Card[52];
    final int bJack=21;
    int maxS=0;

    public Game() {
        
    }
    
    void genrate()
    {
        for (int i = 0; i <13; i++) {
            if(i < 10)
                card[i] = new Card(i+1,i,0);
           else
                card[i] = new Card(10,i,0);

            }
    
          for (int i = 0; i <13; i++) {
            if(i < 10)
                card[i+13] = new Card(i+1,i,1);
           else
                card[i+13] = new Card(10,i,1);

           }
           for (int i = 0; i <13; i++) {
            if(i < 10)
                card[i+26] = new Card(i+1,i,2);
           else
                card[i+26] = new Card(10,i,2);

            }
           for (int i = 0; i <13; i++) {
            if(i < 10)
                card[i+39] = new Card(i+1,i,3);
           else
                card[i+39] = new Card(10,i,3);

            }
            
        }
    Card Randomly()
    {
      
         Random rand = new Random();
         int random = rand.nextInt(52);
         while(card[random]==null)
         {
         random=rand.nextInt(52);
         }
           Card c = new Card(card[random]);
           card[random]=null;
         return c;
    }
        
    void info_player()
    {
        System.out.println("Enter Player Information");
        for (int i = 0; i < player.length; i++) {
            player[i]=new Player();
            player[i].setName(s.next());
            for(int j =0;j<2;j++)
            {
            player[i].c[j]=new Card(Randomly());
            }
            player[i].numofcard+=2;
        }
            
    
    }
    
    void calc()
    {
        for(int i=0;i<4;i++)
        {
            if(player[i].Score>maxS&&!player[i].b)
                maxS=player[i].Score;
        }
    }
            
}

  /* void print()
    {
        for (int i = 0; i < card.length; i++) {
            System.out.print(card[i].getRank());System.out.print(card[i].getSuit());System.out.print(card[i].getValue());
            System.out.println(" ");
            
        }
    
    }*/
        
    
    

