# RoastSharp

![Alt](/resources/roastsharp.gif "RoastSharp")

## Introduction
An open-source, windows forms, .NET Framework application used to log coffee roasts
Currently targetting .NET Framework 4.8
This application uses the open-source library [LiveCharts](https://github.com/Live-Charts/Live-Charts)

## Features
* Provides a live chart of bean temperature and rate over time
* Tablet friendly
* Logs bean temperature via serial com port
* Saves log to a CSV file
* Provides quick roasting event buttons such as first crack start
* Provides a generic event button
* Screenshot of application (alt+prtscrn) allows for simple roast comparisons

## Running
Download the latest release and run RoastSharp.exe

1. Click **Settings**
2. Change settings if applicable
3. Click **Connect**
4. Once the smoothed bean temperature is active, click **Start**
    * If you would like to mark your roast, click the **FC Start**, **FC End**, **SC Start**, **SC End**, and **Event** buttons where applicable
5. When the roast is complete, click **End**

![Alt](/resources/running.png "How to run RoastSharp")

## Temperature Sensor
RoastSharp reads temperature from a serial port. The expected format is a single temperature measurement in deg Celsius per line.

```
21.50
22.75
24.00
.
.
.
223.75
```

This was tested with a MAX6675 chip connected to an arduino using [this library](https://github.com/SirUli/MAX6675) and the following application:

```
#include "max6675.h"
#include <SPI.h>

int thermoSO = 8;
int thermoCS = 9;
int thermoSCK = 10;

MAX6675 thermocouple(thermoSCK, thermoCS, thermoSO);
  
void setup() 
{
  Serial.begin(38400);
  
  delay(1000);
}

void loop() 
{
   Serial.println(thermocouple.readCelsius());
   delay(300);
}
```

Although the MAX6675 chip runs at just over 3 Hz, RoastSharp should technically work at any rate (untested!)

## Development
Development can be done through Visual Studio
The file names are self descriptive