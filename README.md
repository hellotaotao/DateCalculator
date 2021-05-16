# DateCalculator

## How to use
0. Assuming you are on a Linux machine with docker installed.

1. Clone the repo and get into the directory:
```
https://github.com/hellotaotao/DateCalculator.git
cd DateCalculator
```

3. Use docker-composer to run the project:
```
docker-composer up
```

4. Open ```http://localhost:5000/index.html```
This page provides an easy way for you to make requests to the API

5. You may also click on the "Swagger UI" link to goto the Swagger UI page which provides details of the API and also allows you to test the API.

## API specifications
There are 3 endpoints:
```
/api/Days
/api/Weekdays
/api/CompleteWeeks
```
each accepts GET request.

The Swagger UI provides details about the specifications of each API
