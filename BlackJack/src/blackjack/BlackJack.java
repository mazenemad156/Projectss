package blackjack;

import java.util.Scanner;

public class BlackJack {

    static Game game = new Game();

    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int x;
        int max;
        game.genrate();
        game.info_player();
        GUI gui = new GUI();
        gui.runGUI(game.card, game.player[0].c, game.player[1].c, game.player[2].c, game.player[3].c);

        System.out.println("Game is Start");
        for (int i = 0; i < 4; i++) {
            System.out.println("Next Player: " + (i + 1));
            if (i < 3) {
                game.player[i].calcScore();
                 max = game.player[i].Score;
                System.out.println(max);
                System.out.println("1-Hit 2-Stand");
                x = s.nextInt();
                if (x == 1) {
                    while (x == 1) {
                        Card c = new Card(game.Randomly());
                        game.player[i].c[game.player[i].numofcard] = c;
                        game.player[i].numofcard++;
                        gui.updatePlayerHand(c, i);
                        game.player[i].calcScore();
                        max = game.player[i].Score;
                        if(max>game.bJack)
                        {
                        game.player[i].b=true;
                        System.out.println("Player"+(i+1)+"lost");
                        break; 
                        
                        }
                        else if (max==game.bJack){
                            game.player[i].f=true;
                            System.out.println("Player "+(i+1)+"win");
                               return;    
                        }
                        System.out.println(max);
                        System.out.println("1-Hit 2-Stand");
                        x = s.nextInt();
                    }
                    

                }

            } else {
                    game.calc();
                        game.player[i].calcScore();
                        max = game.player[i].Score;
                    if(game.player[i].Score<=game.maxS)
                    {
                        while(game.player[i].Score<=game.maxS)
                        { Card c = new Card(game.Randomly());
                        game.player[i].c[game.player[i].numofcard] = c;
                        gui.updateDealerHand(c, game.card);
                        game.player[i].numofcard++;
                        game.player[i].calcScore();
                        max = game.player[i].Score;
                        
                        if(max>game.bJack)
                        {
                        game.player[i].b=true;
                        System.out.println("delar"+(i+1)+"lost");
                        break; 
                        
                        }
                        else if (max==game.bJack){
                            game.player[i].f=true;
                            System.out.println("dealr"+(i+1)+"win");
                               break;    
                        }
                        
                     }
                    }
            }

        }
        int index=-1 , sc=0;
        for (int i = 0; i <4; i++) {
            if(game.player[i].Score>sc&&!game.player[i].b)
            {
            sc=game.player[i].Score;
            index=i;
            }
        }
        
        if (index!=-1) {
            System.out.println(game.player[index].Name+" WIN");
        }

    }

}
