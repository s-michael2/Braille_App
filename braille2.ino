#include <Servo.h>

// Define motor pins
#define MOTOR_1_PIN 14
#define MOTOR_2_PIN 15
#define MOTOR_3_PIN 16
#define MOTOR_4_PIN 17
#define MOTOR_5_PIN 18
#define MOTOR_6_PIN 19

// Define servo objects
Servo motor1;
Servo motor2;
Servo motor3;
Servo motor4;
Servo motor5;
Servo motor6;

// Function declarations
void raiseMotor(Servo &motor, int angle);
void resetBrailleDisplay();
void processInput();

const int MAX_INPUT = 255; // Maximum number of characters to accept
char inputString[MAX_INPUT]; // Character array to store input
int inputIndex = 0; // Index to track current position in the array

void setup() {
  // Attach servo motors to pins
  motor1.attach(MOTOR_1_PIN);
  motor2.attach(MOTOR_2_PIN);
  motor3.attach(MOTOR_3_PIN);
  motor4.attach(MOTOR_4_PIN);
  motor5.attach(MOTOR_5_PIN);
  motor6.attach(MOTOR_6_PIN);

  // Start serial communication
  Serial.begin(9600);

  inputIndex = 0; // Initialize index
  memset(inputString, 0, MAX_INPUT); // Clear the array
}

void loop() {
  if (Serial.available() > 0) {
    char receivedChar = Serial.read();

    if (receivedChar != '\n' && inputIndex < MAX_INPUT - 1) {
      inputString[inputIndex] = receivedChar;
      inputIndex++;
    } else {
      inputString[inputIndex] = '\0'; // Null-terminate the string
      processInput();
      inputIndex = 0; // Reset index for next input
      memset(inputString, 0, MAX_INPUT); // Clear the array
    }
    //processInput(inputStr[]);
    //delay(2000); // Adjust the delay time as needed
  }
}

void raiseMotor(Servo &motor, int angle) {
  // Raise the motor to the desired position
  motor.write(angle);
}

void resetBrailleDisplay() {
  // Lower all motors
  motor1.write(90);
  motor2.write(90);
  motor3.write(70);
  motor4.write(110);
  motor5.write(115);
  motor6.write(90);
}

void processInput() {
  int length = strlen(inputString);
  for(int i = 0; i <= length; i++){
    if (inputString[i] == 'A' || inputString[i] == 'B'|| inputString[i] =='C' || inputString[i] =='D' || inputString[i] == 'E' || inputString[i] =='F' || inputString[i] =='G' || inputString[i] == 'H' || inputString[i] == 'I' || inputString[i] == 'J' || inputString[i] == 'K' || inputString[i] == 'L' || inputString[i] == 'M' || inputString[i] == 'N' || inputString[i] == 'O' || inputString[i] == 'P' || inputString[i] == 'Q' || inputString[i] == '0' || inputString[i] == 'R' || inputString[i] == 'S' || inputString[i] == 'T' || inputString[i] == 'U' || inputString[i] == 'V' || inputString[i] == 'W' || inputString[i] == 'X' || inputString[i] == 'Y' || inputString[i] == 'Z'){
    resetBrailleDisplay();
    raiseMotor(motor6, 55); // motor 6 indicates a capital letter is following
    delay(4000);  // keep motor 6 on for a little bit before switching to letter indicated
  }
  // input is a capital letter
  if (input == 'A' || input == 'B'|| input =='C' || input =='D' || input == 'E' || input =='F' || input =='G' || input == 'H' || input == 'I' || input == 'J' || input == 'K' || input == 'L' || input == 'M' || input == 'N' || input == 'O' || input == 'P' || input == 'Q' || input == '0' || input == 'R' || input == 'S' || input == 'T' || input == 'U' || input == 'V' || input == 'W' || input == 'X' || input == 'Y' || input == 'Z'){
    resetBrailleDisplay();
    raiseMotor(motor6, 55); // motor 6 indicates a capital letter is following
    delay(4000);  // keep motor 6 on for a little bit before switching to letter indicated
    input = tolower(input); // letter is now lower case to enter switch statement

      // Display character based on input
    switch (input) {
      case 'a':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        break;

      case 'b':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        break;

      case 'c':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor4, 150);
        break;

      case 'd':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor4, 150);
        raiseMotor(motor5, 235);
        break;

      case 'e':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor5, 235);
        break;

      case 'f':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        break;

      case 'g':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        break;

      case 'h':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor5, 235);
        break;

      case 'i':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        break;

      case 'j':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);

        break;

      case 'k':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 135);
        break;

      case 'l':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 135);
        break;

      case 'm':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 135);
        break;

      case 'n':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        break;

      case 'o':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        break;

      case 'p':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 135);
        break;

      case 'q':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        break;

      case 'r':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        break;

      case 's':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 135);
        break;

      case 't':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        break;

      case 'u':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 135);
        raiseMotor(motor6, 55);
        break;

      case 'v':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 135);
        raiseMotor(motor6, 55);
        break;

      case 'w':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        raiseMotor(motor6, 55);
        break;

      case 'x':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 135);
        raiseMotor(motor6, 55);
        break;

      case 'y':

        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        raiseMotor(motor6, 55);
        break;

      case 'z':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        raiseMotor(motor6, 55);
        break;

      default:
        // Invalid input
        break;

    }
  }
  // input is a number
  else if (input == '1' || input == '2' || input == '3' || input == '4' || input == '5' || input == '6' || input == '7' || input == '8' || input == '9' || input == '0'){
    resetBrailleDisplay();
    raiseMotor(motor3, 235);
    raiseMotor(motor4, 150);
    raiseMotor(motor5, 235);
    raiseMotor(motor6, 55); // motor 6 indicates a capital letter is following
    delay(4000);  // keep motor 6 on for a little bit before switching to letter indicated
    switch (input) {
        case '1':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        break;
      
      case '2':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        break;

      case '3':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor4, 150);
        break;
      
      case '4':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor4, 150);
        raiseMotor(motor5, 235);
        break;

      case '5':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor5, 235);
        break;

      case '6':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        break;

      case '7':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        break;

      case '8':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor5, 235);
        break;

      case '9':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        break;

      case '0':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        break;

      case ' ':
        resetBrailleDisplay();
        break;

      default:
        // Invalid input
        break;
    }
  }
  // input is not a capital letter
  else{
      // Display character based on input
    switch (input) {

      case 'a':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        break;

      case 'b':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        break;

      case 'c':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor4, 150);
        break;

      case 'd':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor4, 150);
        raiseMotor(motor5, 235);
        break;

      case 'e':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor5, 235);
        break;

      case 'f':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        break;

      case 'g':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        break;

      case 'h':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor5, 235);
        break;

      case 'i':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        break;

      case 'j':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        break;

      case 'k':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 135);
        break;

      case 'l':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 135);
        break;

      case 'm':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 135);
        break;

      case 'n':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        break;

      case 'o':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        break;

      case 'p':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 135);
        break;

      case 'q':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        break;

      case 'r':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        break;

      case 's':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 135);
        break;

      case 't':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor3, 30);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        break;

      case 'u':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 135);
        raiseMotor(motor6, 55);
        break;

      case 'v':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 135);
        raiseMotor(motor6, 55);
        break;

      case 'w':
        resetBrailleDisplay();
        raiseMotor(motor2, 150);
        raiseMotor(motor4, 30);
        raiseMotor(motor5, 235);
        raiseMotor(motor6, 55);
        break;

      case 'x':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 135);
        raiseMotor(motor6, 55);
        break;

      case 'y':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 150);
        raiseMotor(motor4, 235);
        raiseMotor(motor5, 135);
        raiseMotor(motor6, 55);
        break;

      case 'z':
        resetBrailleDisplay();
        raiseMotor(motor1, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        raiseMotor(motor6, 55);
        break;

      case '!':
        resetBrailleDisplay();
        raiseMotor(motor2, 30);
        raiseMotor(motor3, 235);
        raiseMotor(motor5, 135);
        break;
    }
  }
}
