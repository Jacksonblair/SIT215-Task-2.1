// We define MY_LED to be the LED that we want to blink.
//
// In this tutorial, we're using the blue D7 LED (next to D7 on the Photon
// and Electron, and next to the USB connector on the Argon and Boron).
const pin_t MY_LED = D7;

// The following line is optional, but recommended in most firmware. It
// allows your code to run before the cloud is connected. In this case,
// it will begin blinking almost immediately instead of waiting until
// breathing cyan,
SYSTEM_THREAD(ENABLED);



// Our string to print out in morse code
String output = "jackson";
// Our array of morse code
String morseCode[26] = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
                         ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};

bool print = true;

void dot()
{
	// Turn on the LED
	digitalWrite(MY_LED, HIGH);

	// On for 500ms
	delay(250);
	
	// Turn off
	digitalWrite(MY_LED, LOW); 
	
	// Wait for 500ms
	delay(250);
}

void dash()
{
    // Turn on the LED
	digitalWrite(MY_LED, HIGH);

	// On for 1500ms
	delay(1000);
	
	// Turn off
	digitalWrite(MY_LED, LOW); 
	
	// Wait for 500ms
	delay(250);
}

// The setup() method is called once when the device boots.
void setup()
{
	// In order to set a pin, you must tell Device OS that the pin is
	// an OUTPUT pin. This is often done from setup() since you only need
	// to do it once.
	pinMode(MY_LED, OUTPUT);
	printNameInMorseCode();
}

// The loop() method is called frequently.
void loop()
{
    if (print) printNameInMorseCode();   
}

void printNameInMorseCode()
{
    print = false;
    
    for (int i = 0; i < output.length(); i++)
    {
        // get integer value of char, then get the modulus of it by the unicode value of 'a' 
        // So 'a' becomes 0, 'b' becomes 1, etc...
        int morseIndex = ((int)output[i])%97;
        
		for (int i = 0; i < morseCode[morseIndex].length(); i++)
		{
			morseCode[morseIndex][i] == '-' ? dash() : dot();
		}
		
		// Wait for 1000ms between characters
	    delay(1500);
    }
    
    print = true;
}
