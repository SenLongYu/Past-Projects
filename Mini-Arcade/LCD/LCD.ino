// include the library code:
#include <LiquidCrystal.h>
#include <OneMsTaskTimer.h>

int points = 0;
int pointsx = 15;

OneMsTaskTimer_t timerTask = {100, playActionTimerISR, 0, 0};

typedef struct xy_struct
{
  int x;
  int y;
}xy;

typedef struct obstical
{
  xy position;
  bool active = 0; //check if the obstical is active
  int type = 0; //type of the obstical
  int checked = 0; //if the obstical has already been checked
} obstical;

obstical bonus; //reusing the obstical struct, the "type" memeber is probably not going to be used
obstical nuke;

int nukeCount = 0; 
int count = 0; //incrementer
int delaycnt = 0; //incrementer
int shieldsInUse = 0; //amount of obsticals in use
int maxShields = 2; //max amount of obsticals
int deelaay = 1000; //initial delay between each obstical appearing

byte hero[8] = 
{
  B00100,
  B00100,
  B01110,
  B01110,
  B01110,
  B11111,
  B00100,
  B00100,
};

byte sticc[8] = 
{
  B11111,
  B10001,
  B10001,
  B10101,
  B10001,
  B10001,
  B11111,
  B00000, //all obsticals are floating since it looks better
};

byte slash[8] =
{
  B11000,
  B00100,
  B00010,
  B00001,
  B00001,
  B00010,
  B00100,
  B11000,
};

byte RoundLookingThing[8] = 
{
  B01000,
  B00100,
  B00100,
  B01110,
  B11111,
  B11111,
  B11111,
  B01110,
};

byte special[8] =
{
  B11111,
  B10101,
  B10101,
  B11111,
  B10101,
  B10101,
  B11111,
  B00000,
};

int const obstcount = 10;
obstical obsticals[obstcount]; //a bunch of obsticals
obstical oldObsticals[obstcount];

xy HeroLocation;
xy OldLocation;
xy sticcLocation = {15,1};
xy oldSticcLocation;

enum PlayerActionStates{GameInit, Gamestart, WaitingForAction, MoveForwards, MoveBackwards, MoveUp, MoveDown, gameOver};
PlayerActionStates PAS;

bool PlayerActionFlag = 0;
bool BonusThreadFlag = 0;
bool NukeThreadFlag = 0;
bool ScreenThreadFlag = 0;

// initialize the library with the numbers of the interface pins
LiquidCrystal lcd(P6_7, P2_3, P2_6, P2_4, P5_6, P6_6);

void setup() 
{
  lcd.begin(16, 2);
  lcd.createChar(0, hero);
  lcd.createChar(1, sticc);
  lcd.createChar(2, special);
  lcd.createChar(3, RoundLookingThing);
  lcd.createChar(4, slash);
  Serial.begin(9600);

  OneMsTaskTimer::add(&timerTask);
  OneMsTaskTimer::start();

  for(int i=0; i<obstcount; i++)
  {
    obsticals[i].position.x = 16;
    obsticals[i].active = 0;
    obsticals[i].type = 0;
    obsticals[i].checked = 0;
  }

  for(int i=0; i<(int)(obstcount/2); i++) //half of the obsticals will be on top
  {
    obsticals[i].position.y = 0;
  }

  for(int i=(int)(obstcount/2); i<obstcount; i++) //half of the obsticals will be on the bottom, screw random numbers
  {
    obsticals[i].position.y = 1;
  }

  for(int i=0; i<(int)(obstcount/2); i=i+2) //half of the obsticals on top will be of type 0
  {
    obsticals[i].type = 0;
  }

  for(int i=(int)(obstcount/2); i<obstcount; i=i+2) //half of the obsticals on top will be of type 1
  {
    obsticals[i].type = 1;
  }

  obsticals[0].type = 0;
  
}

void loop() {
  delay(100);
  //Serial.print("(LCD Wokring)");
}

void eraseShield(int i)
{
  lcd.setCursor(oldObsticals[i].position.x, oldObsticals[i].position.y); //these code are given, just added an input parameter to help navigation
  lcd.print(" ");
}

void playActionTimerISR()
{
  PlayerActionFlag = 1;
  BonusThreadFlag = 1;
  NukeThreadFlag = 1;
  ScreenThreadFlag = 1;
}
