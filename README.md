# DateCalculator

## How to use

0. Assuming you are on a Linux/Windows/Mac computer with docker installed.

1. Clone the repo and get into the directory:

```
git clone https://github.com/hellotaotao/DateCalculator.git
```

2. Go into the directory

```
cd DateCalculator
```

3. Use docker-compose to run the project:

```
docker-compose up
```

4. Open [http://localhost:5000/index.html](http://localhost:5000/index.html)
   This page provides an easy way for you to make requests to the API

5. You may also click on the "Swagger UI" link in bottom of the page (or [here](http://localhost:5000/swagger/index.html)) to goto the Swagger UI which provides details of the API and also allows you to test the API.

## API specifications

There are 3 endpoints:

```
/api/Days
/api/Weekdays
/api/CompleteWeeks
```

Each accepts a GET request that has 3 parameters:

1 and 2: DateTime provided in string format, with or without timezone information. Error will be returned if the string could not be parsed to DateTime object.
3: An integer (0, 1, 2, or 3) specifying the expected return value is in seconds, minutes, hours, or years.

If the provided DateTime parameters does not contain timezone information, they will be seen as provided in local timezone of the running instance.

If the provided DateTime parameters contains timezone information, they will be converted to local timezone of the running instance before doing further calculations.

The Swagger UI provides details about the specifications of each API

There is another endpoint `/api/DateTimeParse` which accepts a DateTime string, and returns the parsed DateTime object. This helps to identify the local timezone of the running instance.
