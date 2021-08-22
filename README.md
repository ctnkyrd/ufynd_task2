# Task 2: Reporting

## Environment
Framework: .Net 5

### Projects 
* task2.app: .Net Console Application
* task2.test: .Net NUnit Test Project

## Build & Run
```
dotnet build && dotnet test

dotnet run -p task2.app/task2.app.csproj
```
## Output
Output file: HotelRateReport_ddMMyy-HHss.xlsx

## Automation Suggestion
After the report is created successfully, System.Net.Mail can be used to send an email with attachment. This process can be automated to run on scheduled time by:
* creating a web application either by .Net Standart or .Net Core and use HangFire (https://www.hangfire.io/) to create scheduled background jobs.
* creating a windows service can also be a simple solution for scheduled jobs
* if the email task will be called once a day or so, windows task scheduler can be used also.
