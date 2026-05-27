# TechM ParaBank Assessment – UI Automation

##  Project Overview

This project automates the **Login functionality** of the ParaBank web application:

 https://parabank.parasoft.com/

The framework is built using:

* C#
* .NET 8
* Reqnroll (SpecFlow successor)
* Selenium WebDriver
* WebDriverManager
* NUnit
* FluentAssertions
* Allure Reporting
* GitHub Actions (CI)

---

## Framework Design

The framework follows best practices:

* Page Object Model (POM)
* BDD using Gherkin (Reqnroll)
* Separation of concerns
* Reusable utilities (DriverFactory, WaitHelper)
* Scalable folder structure

---

## Project Structure

```
TechM_ParaBank_Assessment
│
├── Features
├── StepDefinitions
├── Pages
├── Drivers
├── Hooks
├── Utilities
├── allureConfig.json
├── reqnroll.json
```

---

##  Prerequisites

Ensure the following are installed:

* .NET SDK 8+
* Google Chrome (latest)
* Git
* Java 17 (for Allure)
* Python (optional, for viewing report locally)

---

##  Setup Instructions

### 1. Clone Repository

```
git clone <your-repo-url>
cd TechM_ParaBank_Assessment
```

---

### 2. Restore Dependencies

```
dotnet restore
```

---

### 3. Build Project

```
dotnet build
```

---

### 4. Run Tests

```
dotnet test
```

---

## Allure Report (Local)

### Step 1: Ensure tests are executed

```
dotnet test
```

### Step 2: Generate report

```
allure serve allure-results
```

If Allure is not installed locally, use:

```
allure generate allure-results --clean -o allure-report
```

---

### Important Note (Common Issue)

Opening report directly like:

```
index.html 
```

will show **Loading...**

Correct way:

```
cd allure-report
python -m http.server 8080
```

Then open:

```
http://localhost:8080
```

---

##  GitHub Actions (CI)

The pipeline performs:

* Build
* Test execution
* Allure report generation
* Artifact upload

---

###  Key Fixes Implemented

During setup, the following issues were handled:

*  Deprecated GitHub action → updated to `upload-artifact@v4`
*  Allure installation failure via Chocolatey → replaced with Maven download
*  PATH issues → used direct `.bat` execution
*  Windows wildcard issue (`**`) → replaced with PowerShell directory resolution
*  Allure report not loading → fixed using local server
*  Pipeline stopping on failure → fixed using:

  * `continue-on-error: true`
  * `if: always()`

---

##  Viewing Report from CI

1. Go to GitHub → Actions
2. Open latest run
3. Download artifact: `allure-report`
4. Extract ZIP
5. Run:

```
python -m http.server 8080
```

6. Open:

```
http://localhost:8080
```

---

##  Test Coverage (Login Flow)

* Valid login
* Invalid credentials
* Missing username
* Missing password
* UI validation (fields & links)
* System behavior validation

---

##  Key Highlights

* Clean architecture
* Scalable design
* CI integrated
* Robust synchronization
* Independent test execution
