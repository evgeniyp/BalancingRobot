int right_dir = 7;
int right_pwm = 9;

int left_dir = 8;
int left_pwm = 10;

int max_speed = 255;

int led = 13;

void set_left_motor(int aSpeed)
{
  if (aSpeed > 0){
    digitalWrite(left_dir, HIGH);
    analogWrite(left_pwm, aSpeed);
  }
  else if (aSpeed < 0){
    digitalWrite(left_dir, LOW);
    analogWrite(left_pwm, -aSpeed);
  }
  else {
    digitalWrite(left_dir, LOW);
    digitalWrite(left_pwm, LOW);
  }
}

void set_right_motor(int aSpeed)
{
  if (aSpeed > 0){
    digitalWrite(right_dir, HIGH);
    analogWrite(right_pwm, aSpeed);
  }
  else if (aSpeed < 0){
    digitalWrite(right_dir, LOW);
    analogWrite(right_pwm, -aSpeed);
  }
  else {
    digitalWrite(right_dir, LOW);
    digitalWrite(right_pwm, LOW);
  }
}

void set_motors(int aLeft, int aRight)
{
  set_left_motor(aLeft);
  set_right_motor(aRight);
}

void setup_motors()
{
  pinMode(right_dir, OUTPUT);
  pinMode(right_pwm, OUTPUT);
  pinMode(left_dir, OUTPUT);
  pinMode(left_pwm, OUTPUT);
  pinMode(led, OUTPUT);
  set_motors(0,0);
}
