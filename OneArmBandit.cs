using System;
using System.Collections.Generic;
using System.Linq;

public class OneArmBandit {

  private int PushCoin(){
    Console.WriteLine("Ile monet chcesz wrzucić do automatu: ");
    int coins = Convert.ToInt32(Console.ReadLine());   
    Console.WriteLine("Wrzucam " + coins + " monet(y) do automatu");
    return coins;
  }
  
  public List<string> GameRunner(int iterator, int round){
    Console.Write(iterator + " Losowanie z " + round +": ");
    string[] figureArr = {"7","Cherry","Grape"};
    Random rnd = new Random();
    int r1 = rnd.Next(3);
    string fig1 = figureArr[r1];
    int r2 = rnd.Next(3);
    string fig2 = figureArr[r2];
    int r3 = rnd.Next(3);
    string fig3 = figureArr[r3];

    List<string> playerArray = new List<string>();
    playerArray.Add(fig1);
    playerArray.Add(fig2);
    playerArray.Add(fig3);
    return playerArray;

    }
  
  public int GetPrice( List<string> playerResultsList, int price){
    string[] sevens = {"7","7","7" };    
    string[] grapes = {"Grape","Grape","Grape"};
    string[] cherries = {"Cherry","Cherry","Cherry"};
    List<string> sevensLists = new List<string>(sevens);
    List<string> grapesLists = new List<string>(grapes);
    List<string> cherriesLists = new List<string>(cherries);
    
    bool isSevens = Enumerable.SequenceEqual(playerResultsList, sevensLists);
    bool isGrapes = Enumerable.SequenceEqual(playerResultsList, grapesLists);
    bool isCherries = Enumerable.SequenceEqual(playerResultsList, cherriesLists);

    if (isSevens){
        return win100(price, playerResultsList);
	}
    
    if (isGrapes){
        return win200(price, playerResultsList);
	}

    if (isCherries){
        return win300(price, playerResultsList);
    }

    return 0;
	
  }

  private int win100(int price,List<string> list){
    Console.Write("Wylosowałeś ");
    DisplayResults(list);
    Console.WriteLine("Wygrywasz 100PLN");
    price+=100;
    return price;
  }


  private int win200(int price, List<string> list){

    Console.Write("Wylosowałeś ");
    DisplayResults(list);
    Console.WriteLine("Wygrywasz 200PLN");
    price+=200;

    return price;

  }


  private int win300(int price,List<string> list){
    Console.Write("Wylosowałeś ");
    DisplayResults(list);
    Console.WriteLine("Wygrywasz 300PLN");
    price+=300;
    return price;

  }

  public void RunMachine() {
    int playerPrice = 0;
    int gameRound = PushCoin();
    for (int i = 1; i <= gameRound; i++){
      List<string> playerList = GameRunner(i, gameRound);
      DisplayResults(playerList);
      playerPrice += GetPrice(playerList,playerPrice);
      DisplayPrice(playerPrice);
    }
    DisplayFinalWon(playerPrice);

    
     
  }

  private void DisplayResults(List<string> arr){
      Console.WriteLine(string.Join(" ", arr));
  }

  private void DisplayPrice(int wonPrice){
      Console.WriteLine("Twoja aktualna wygrana to: " + wonPrice);
      Console.WriteLine("\n==============================================\n");
  }

  private void DisplayFinalWon(int wonPrice){
          Console.WriteLine("\n========================\n Gratuluję, łącznie Wygraleś/aś "+ wonPrice + " PLN.\n========================");
  }
}