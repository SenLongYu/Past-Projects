#include <LiquidCrystal.h>

void setupScreen()
{
  //lcd.begin(16, 2);
  lcd.clear();
  lcd.setCursor(0, 1);
  lcd.write(byte(0));
  Serial.begin(9600);
}

void loopScreen()
{
  while(ScreenThreadFlag == 0)
  {
    delay(10);
  }
  ScreenThreadFlag = 0;

  //Serial.print("(Screen Thread Wokring) ");

  if(PAS!=gameOver && PAS!=Gamestart && PAS!=GameInit) // if the game is not over and not at the starting screen
  {
    jumpFlag = 0;
    
    eraseHero();
    drawHero(); 

    //detect collision
    for(int i=0; i<obstcount; i++)
    {     
      if(HeroLocation.x==obsticals[i].position.x && HeroLocation.y==obsticals[i].position.y)
      {
        Serial.print("Game Over");
        
        Serial.print("Hero Position: ");
        Serial.print(HeroLocation.x);
        Serial.print(" ");
        Serial.println(HeroLocation.y);

        Serial.print("Obstical Position: ");
        Serial.print(obsticals[i].position.x);
        Serial.print(" ");
        Serial.println(obsticals[i].position.y);
        
        gameOva();
      }
    }
  }

  /*Serial.print("Sticc position: ");
  Serial.print(sticcLocation.x);
  Serial.print(" ");
  Serial.println(sticcLocation.y);*/

}

void eraseHero()
{
  lcd.setCursor(OldLocation.x, OldLocation.y);
  lcd.print(" ");
}

void drawHero()
{
  lcd.setCursor(HeroLocation.x, HeroLocation.y);
  lcd.write(byte(0));
  OldLocation = HeroLocation;
}

void eraseSticc()
{
  lcd.setCursor(oldSticcLocation.x, oldSticcLocation.y);
  lcd.print(" ");//erase the sticc
}

void drawSticc()
{
  srand(millis());
  if(sticcLocation.x < 0)//resetting the sticc
  {
    sticcLocation.x = rand()%10+8;
  }
  
  //increment the sticc
  sticcLocation.x = sticcLocation.x-1;

  //draw new sticc
  lcd.setCursor(sticcLocation.x, sticcLocation.y);
  lcd.write(byte(1));
  /*Serial.println(sticcLocation.x);
  Serial.println(sticcLocation.y);
  Serial.println("Wrong");*/

  oldSticcLocation = sticcLocation;
}

void gameOva()
{
  PAS = gameOver;
  
  lcd.clear();
  lcd.setCursor(4, 0);
  lcd.print("YOU DIED");
  lcd.setCursor(4, 1);
  lcd.print("Points: ");
  lcd.print((points-1)); //taking out the points that got counted when the player died
  
}
