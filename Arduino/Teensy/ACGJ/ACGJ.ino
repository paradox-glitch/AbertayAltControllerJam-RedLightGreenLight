/* morgan finney and jack edgar
 * abertay alt controller jam
 * feb 2020
 * for red light green light
 */

#include <Bounce.h>
#include <SharpIR.h>

#define IRPin 20
#define IRPin2 19                                   
#define model 1080

const int player1Pin = 1;
const int player2Pin = 2;
const int greenPin = 3;
const int redPin = 4;

const int ledPin = 13;

int distance;
int distance2;
SharpIR mySensor = SharpIR(IRPin, model);
SharpIR mySensor2 = SharpIR(IRPin2, model);

Bounce player1Button(player1Pin,10);
Bounce player2Button(player2Pin,10);
Bounce gButton(greenPin,10);
Bounce rButton(redPin,10);

void setup() {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
  // put your setup code here, to run once:
  pinMode(player1Pin, INPUT_PULLUP);
  pinMode(player2Pin, INPUT_PULLUP);
  pinMode(greenPin, INPUT_PULLUP);
  pinMode(redPin, INPUT_PULLUP);

  pinMode(ledPin, OUTPUT);
  
  pinMode(IRPin, INPUT);
  pinMode(IRPin2, INPUT);
  Serial.begin(9600);

  digitalWrite(ledPin, HIGH);   // set the LED on
}

void loop() {
  // put your main code here, to run repeatedly:
  if (player1Button.update())
  {
    if(player1Button.fallingEdge())
    {
      Keyboard.press(KEY_1);
    }
    else if(player1Button.risingEdge())
    {
      Keyboard.release(KEY_1);
    }
  }

  if (player2Button.update())
  {
    if(player2Button.fallingEdge())
    {
      Keyboard.press(KEY_2);
    }
    else if(player2Button.risingEdge())
    {
      Keyboard.release(KEY_2);
    }
  }

  if (gButton.update())
  {
    if(gButton.fallingEdge())
    {
      Keyboard.press(KEY_G);
    }
    else if(gButton.risingEdge())
    {
      Keyboard.release(KEY_G);
    }
  }

  if (rButton.update())
  {
    if(rButton.fallingEdge())
    {
      Keyboard.press(KEY_R);
    }
    else if(rButton.risingEdge())
    {
      Keyboard.release(KEY_R);
    }
  }
  
  distance = mySensor.distance();
  Serial.print("Mean distance: ");
  Serial.print(distance);
  Serial.println(" cm");

  if (distance < 12)
    Keyboard.press(KEY_A);
  else
    Keyboard.release(KEY_A);

  distance2 = mySensor2.distance();
  Serial.print("Mean distance2: ");
  Serial.print(distance2);
  Serial.println(" cm");

  if (distance2 < 12)
    Keyboard.press(KEY_B);
  else
    Keyboard.release(KEY_B);

  delay(16);
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
