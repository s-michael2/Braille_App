#include <Servo.h>

// Define motor pins
#define MOTOR_1_PIN 14
#define MOTOR_2_PIN 15
#define MOTOR_3_PIN 16
#define MOTOR_4_PIN 17
#define MOTOR_5_PIN 18
#define MOTOR_6_PIN 19
#define MOTOR_7_PIN 2
#define MOTOR_8_PIN 12
#define MOTOR_9_PIN 7
#define MOTOR_10_PIN 8


// Define servo objects
Servo motor1;
Servo motor2;
Servo motor3;
Servo motor4;
Servo motor5;
Servo motor6;
Servo motor7;
Servo motor8;
Servo motor9;
Servo motor10;

// Function declarations
void raiseMotor(Servo &motor, int angle);
void resetBrailleDisplay();
void processInput(String input);


void setup() {
  
  // Attach servo motors to pins
  motor1.attach(MOTOR_1_PIN);
  motor2.attach(MOTOR_2_PIN);
  motor3.attach(MOTOR_3_PIN);
  motor4.attach(MOTOR_4_PIN);
  motor5.attach(MOTOR_5_PIN);
  motor6.attach(MOTOR_6_PIN);
  motor7.attach(MOTOR_7_PIN);
  motor8.attach(MOTOR_8_PIN);
  motor9.attach(MOTOR_9_PIN);
  motor10.attach(MOTOR_10_PIN);

  // Start serial communication
  Serial.begin(9600);

  resetBrailleDisplay();
}


// main loop
// spins the correct motors based on what is typed on the keyboard
void loop() {
  while (Serial.available() > 0) {
    String input = Serial.readString();
    processInput(input);
    resetBrailleDisplay();
  }
}


// Raise the motor to the desired position
void raiseMotor(Servo &motor, int angle) {
  motor.write(angle);
}


// puts all motors to their initial position
void resetBrailleDisplay() {
  delay(2000);
  // Lower all motors
  motor1.write(0);
  motor2.write(0);
  motor3.write(0);
  motor4.write(0);
  motor5.write(0);
  motor6.write(0);
  motor6.write(0);
  motor7.write(0);
  motor8.write(0);
  motor9.write(0);
  motor10.write(0);
  delay(1000);
}

// checks if input is an Upper case letter or if the entire word in capitalized
void checkUpperCase(String input){
  bool isCap = false; // true if letter is capitalized
  bool isAllCap = false;  // true if whole word is capitalized
  Serial.println("CheckUpperCase Input: " + input); // for debugging purposes only
  int wordEnd = input.indexOf(' '); // splits up input into words at a space
  // word ends at the end of the input
  if (wordEnd == -1) {
    wordEnd = input.length()-1;
  }
  int length = input.substring(0, wordEnd).length();  // sets length to the length of the word
  bool isUpper = false; // true if letter is capitalized
  // goes through input checking case of the letters
  for(int i=0; i<length;i++){
    char currentchar = input[i];  // assigns currentchar to letter at position i
    // current letter is uppercase
    if (i==0 && isUpperCase(currentchar))
    {
      isCap = true;
      isUpper = true;
    }
    // entire word is capitalized
    else if (isUpper && isUpperCase(currentchar))
    {
      isAllCap = true;
    }
    // character is a non-uppercase letter
    else if (isalpha(currentchar))
    {
      isAllCap = false;
    }
  }
  // single letter is capitalized, motor 6 raises once
  if (isUpper){
      Serial.println("is Upper");
      raiseMotor(motor10, 90);
  }
}

// takes input and determines what it is so motors can move correctly
void processInput(String input) {
  int length = input.length();  // length of input
  Serial.println(input);
  bool isDigits = false;  // true if input is a number
  bool isNonDigit = false;  // true if input is not a number, anything else
  // goes through input
  for(int i=0; i<length;i++){
    char currentchar = input[i];  // sets currentchar to the character at position i
    currentchar = tolower(currentchar); // makes currentchar lowercase
    resetBrailleDisplay();
    // currentchar is a digit
    if(isDigit(currentchar)){
      doDigit(currentchar); // moves motor for number shown
      doDigit('#'); // moves motors to signify number

    }
    // current character is not a number
    else{
      // the last character was not something other than a number
      if(!isNonDigit){
        checkUpperCase(input.substring(i)); // check the case
      }
      // current character is a space then bools are reset
      if (currentchar == ' ')
      {
        isNonDigit = false;
        isDigits = false;
      }
      // current character is a letter or special character
      else {
        doNonDigit(currentchar);  // moves motors for letter or character (non-digit)
        isDigits = false;
        isNonDigit = true;
      }
    }
  }
}

// motor setup for ever number or cases to move motors to symbolize it is a number/letter after a number
void doDigit(char input){
  switch (input) {
    case '#': // symbolize a number is coming
      raiseMotor(motor7, 90);
      raiseMotor(motor8, 90);
      raiseMotor(motor9, 90);
      raiseMotor(motor10, 90);
      break;
    case '1':
      raiseMotor(motor1, 90);
      break;
    case '2':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      break;
    case '3':
      raiseMotor(motor1, 90);
      raiseMotor(motor4, 90);
      break;
    case '4':
      raiseMotor(motor1, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case '5':
      raiseMotor(motor1, 90);
      raiseMotor(motor5, 90);
      break;
    case '6':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      break;
    case '7':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case '8':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor5, 90);
      break;
    case '9':
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      break;
    case '0':
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    default:
      // Invalid input
      break;
  }
}

// motor setup for everything that is not a number
void doNonDigit(char input){
  switch (input) {
    case 'a':
      raiseMotor(motor1, 90);
      break;
    case 'b':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      break;
    case 'c':
      raiseMotor(motor1, 90);
      raiseMotor(motor4, 90);
      break;
    case 'd':
      raiseMotor(motor1, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case 'e':
      raiseMotor(motor1, 90);
      raiseMotor(motor5, 90);
      break;
    case 'f':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      break;
    case 'g':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case 'h':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor5, 90);
      break;
    case 'i':
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      break;
    case 'j':
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case 'k':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      break;
    case 'l':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      break;
    case 'm':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      break;
    case 'n':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case 'o':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor5, 90);
      break;
    case 'p':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      break;
    case 'q':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case 'r':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor5, 90);
      break;
    case 's':
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      break;
    case 't':
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      break;
    case 'u':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor6, 90);
      break;
    case 'v':
      raiseMotor(motor1, 90);
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor6, 90);
      break;
    case 'w':
      raiseMotor(motor2, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      raiseMotor(motor6, 90);
      break;
    case 'x':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor6, 90);
      break;
    case 'y':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor4, 90);
      raiseMotor(motor5, 90);
      raiseMotor(motor6, 90);
      break;
    case 'z':
      raiseMotor(motor1, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor5, 90);
      raiseMotor(motor6, 90);
      break;
    case '!':
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor5, 90);
      break;
    case '.':
      raiseMotor(motor2, 90);
      raiseMotor(motor5, 90);
      raiseMotor(motor6, 90);
      break;
    case ',':
      raiseMotor(motor2, 90);
      break;
    case '?':
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      raiseMotor(motor6, 90);
      break;
    case ';':
      raiseMotor(motor2, 90);
      raiseMotor(motor3, 90);
      break;
    case ':':
      raiseMotor(motor2, 90);
      raiseMotor(motor5, 90);
      break;
    case '\'':
      raiseMotor(motor3, 90);
      break;
    default:
      // Invalid input
      break;
  }
}

