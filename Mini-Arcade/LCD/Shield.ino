#include <LiquidCrystal.h>
#include <OneMsTaskTimer.h>

int delaytrigger = 3;
int const delaymax = 250; //minimum delay

void setupShield()
{
  //lcd.begin(16, 2);
  Serial.begin(9600);
}

void loopShield()
{

  if(PAS!=gameOver && PAS!=Gamestart && PAS!=GameInit) 
  {
    createShield(); //try to create an obstical, designed to work some of the time
    advanceShield(); //increment all obstical positions by the appropriate amount
    //overLap(); //if two obstical over lap, delete the one thas has a lower type value
    deleteShield(); //mark off the obsticals that are no longer on the screen, can be intergrated into other fucntions but I'm not going to
  }

  if(PAS!=gameOver && PAS!=Gamestart && PAS!=GameInit) 
  {
    for(int i=0; i<obstcount; i++) //counting points
      {
        if((HeroLocation.x == obsticals[i].position.x && obsticals[i].checked == 0) || (HeroLocation.x > obsticals[i].position.x && obsticals[i].checked == 0))
        {
          points++;
          delaycnt++;

          Serial.print("Points updated: ");
          Serial.println(points);
          
          obsticals[i].checked = 1; //prevent a sigular obstical to grant multiple points
        }
      }
   }

  if(PAS!=gameOver && PAS!=Gamestart && PAS!=GameInit) 
  {
    if(delaycnt >= delaytrigger && deelaay > delaymax)
    {
      if(maxShields < obstcount)
      {
        maxShields = maxShields + 1; //increment the amount of shields that can be in use when reducing delay
        Serial.print("MaxShields updated: ");
        Serial.println(maxShields);
      }
      
      deelaay = deelaay - (delaycnt * 20); //reducing the delay
      delaycnt = 0;
      
      srand(millis());
      delaytrigger = rand()%4 + 2;
      Serial.print("Delay reduced: ");
      Serial.println(deelaay);
    }
  }

  delay(deelaay);
}

void overLap() //this functionality is no longer needed, but since I spent so much time writing it, I will keep it here
{
  for (int i = 0; i<obstcount; i++)
  {
    for(int j = obstcount-1; j>i; j--)
    {
      if((obsticals[i].position.x == obsticals[j].position.x) && (obsticals[i].position.y == obsticals[j].position.y))
      {

        Serial.print("i: ");
        Serial.print(i);
        Serial.print("j: ");
        Serial.println(j);

        Serial.print("x[i]: ");
        Serial.print(obsticals[i].position.x);
        Serial.print(" y[i]: ");
        Serial.println(obsticals[i].position.y);

        Serial.print("x[j]: ");
        Serial.print(obsticals[j].position.x);
        Serial.print(" y[j]: ");
        Serial.println(obsticals[j].position.y);
        
        if(obsticals[i].type < obsticals[j].type)
        {
          Serial.print("Overlap detected 1");
          obsticals[i].position.x = 16;
          obsticals[i].active = 0;

          lcd.setCursor(oldObsticals[i].position.x, oldObsticals[i].position.y);
          lcd.print(" ");
        }
        else if(obsticals[i].type > obsticals[j].type)
        {
          Serial.println("Overlap detected 2");
          obsticals[j].position.x = 16;
          obsticals[j].active = 0;
          
          lcd.setCursor(oldObsticals[i].position.x, oldObsticals[i].position.y);
          lcd.print(" ");
        }
        else if(obsticals[i].type == obsticals[j].type)
        {
          Serial.println("Overlap detected 3");
          obsticals[j].position.x = 16;
          obsticals[j].active = 0;
          
          lcd.setCursor(oldObsticals[i].position.x, oldObsticals[i].position.y);
          lcd.print(" ");
        }
      }
    }
  }
}

void createShield()
{
  int r;
  int l;
  srand(millis());
  l = rand()%8;

  if(shieldsInUse < maxShields)
  {
    for(int i=0; i<l; i++) //generates obsticals at pseudo-random intervals
    {
      srand(millis());
      r = rand()%obstcount; //generates a seed each loop
      
      if(obsticals[r].active == 0) //try to find an inactive obstical
      {
        obsticals[r].active = 1; //make it active
  
        /*Serial.print("Activating element: ");
        Serial.println(r);*/
        
        lcd.setCursor(obsticals[r].position.x, obsticals[r].position.y); //set curser to location
        
        /*Serial.print("Drawing: x: ");
        Serial.print(obsticals[r].position.x);
        Serial.print(" y: ");
        Serial.print(obsticals[r].position.y);
        Serial.print(" State: ");
        Serial.println(obsticals[r].active);*/
        
        if(obsticals[r].type == 0) //draw the appropriate obstical
        {
          lcd.write(byte(1));
        }
        else if(obsticals[r].type == 1)
        {
          lcd.write(byte(2));
        }
        shieldsInUse++;

        Serial.print("Shield Count Updated: ");
        Serial.println(shieldsInUse);
        break; //exits the loop when exactly one obstical has been draw to screen
      }
      else
      {
        //Serial.println("Nothing to be drawn"); //nothing really needs to be here, but I'm having it print something anyway
      }
    }
  }
}

void advanceShield()
{
  for (int i = 0; i<obstcount; i++) //go through the entire array
  {
    //logics are put in place to ensure that an obstical of a higher type are always on top
    if (obsticals[i].active == 1 && obsticals[i].type == 0) //find active obsticals that's of type 0
    {
      /*Serial.print("Current Active Elements: ");
      Serial.println(i);*/
      
      eraseShield(i); //advance the appropiate obstical
      drawShield(i);
    }
  }
  
  for (int i = 0; i<obstcount; i++) //go through the entire array
  {
    if (obsticals[i].active == 1 && obsticals[i].type == 1) //find active obsticals that's of type 1
    {
      /*Serial.print("Current Active Elements: ");
      Serial.println(i);*/
      
      eraseShield(i); //advance the appropiate obstical
      drawShield(i);
    }
  }
}

void drawShield(int i)
{
  if(obsticals[i].type == 0)
  {
    obsticals[i].position.x = obsticals[i].position.x - 1; //type 0 obsticals march left 1 unit at a time
    lcd.setCursor(obsticals[i].position.x, obsticals[i].position.y);
    lcd.write(byte(1));
    //overLap();
    oldObsticals[i].position = obsticals[i].position; //remember the position
  }
  else if(obsticals[i].type == 1) //if else works fine here, but if the type gets numerous, switch statements are better
  {
    obsticals[i].position.x = obsticals[i].position.x - 2; //type 2 obsticals march left 2 unit at a time
    lcd.setCursor(obsticals[i].position.x, obsticals[i].position.y);
    lcd.write(byte(2));
    //overLap();
    oldObsticals[i].position = obsticals[i].position; //remember the position
  }
}

void deleteShield()
{
  for(int i=0; i<obstcount; i++) //check every element of the array
  {
    if(obsticals[i].position.x < 0 ) //still erase the obstical if it is offscreen, but wait for one more clock cycle for collision detection
    {
      eraseShield(i);
    }
    
    if(obsticals[i].position.x < -1 ) //-1 to prevent the object disappearing before making collision
    {
      /*Serial.print("Deactivating element: ");
      Serial.println(i);*/
      
      obsticals[i].active = 0; //make the obstical inactive
      obsticals[i].position.x = 16; //reset position
      obsticals[i].checked = 0;
      
      shieldsInUse--;
      Serial.print("Shield Count Updated: ");
      Serial.println(shieldsInUse);
    }
  }
}
