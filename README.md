# 🚗 DVLD – Driving & Vehicle License Department

A comprehensive **Driving License Management System (DVLD)** designed to manage people, driving licenses, applications, tests, and the different services provided by a Driving & Vehicle License Department.

The system simulates the complete workflow of issuing and managing driving licenses, from creating an application and scheduling tests to issuing, renewing, replacing, or releasing a license.

---

## 📌 Project Overview

DVLD provides an integrated system for managing the main operations of a driving license department.

The system allows employees to:

- Manage people and their personal information.
- Manage system users and their permissions.
- Create and manage driving license applications.
- Schedule and manage driving tests.
- Issue driving licenses after completing all requirements.
- Renew existing licenses.
- Issue replacement licenses for lost or damaged licenses.
- Release suspended licenses.
- Issue international driving licenses.
- Search and track applicants, applications, and licenses.

---

## ⚙️ Main Services

### 🪪 First-Time Driving License

Applicants can apply for a specific driving license class.

The system validates:

- Applicant's minimum age.
- Existing licenses of the same class.
- Required documents.
- Completion of the required tests.

The applicant must successfully complete:

1. 👁️ Vision Test
2. 📝 Written/Theory Test
3. 🚘 Practical Driving Test

After successfully completing all requirements, the driving license is issued.

---

### 🔄 Retake Test

Allows applicants who failed a test to schedule another attempt.

The new application is linked to the original application, and the applicant must pay the required test fees again.

---

### ♻️ License Renewal

Allows drivers to renew an expired driving license after completing the required vision test and submitting the expired license.

---

### 📄 Lost License Replacement

Allows a driver to request a replacement for a lost license after verifying that the license is not currently suspended.

---

### 🛠️ Damaged License Replacement

Allows a driver to replace a damaged license while preserving the history of the replacement operation.

---

### 🔓 Release Suspended License

Allows a suspended license to be released after the required fine has been paid.

The system records the suspension and release information.

---

### 🌍 International Driving License

Allows eligible holders of a valid regular driving license to obtain an international driving license.

The system prevents having more than one active international license for the same driver.

---

## 🪪 Driving License Classes

The system supports **7 license classes**:

| Class | Description |
|---|---|
| 1 | Small Motorcycle |
| 2 | Heavy Motorcycle |
| 3 | Regular Car |
| 4 | Agricultural Vehicles |
| 5 | Small & Medium Buses |
| 6 | Trucks & Heavy Vehicles |

Each license class contains configurable information such as:

- Minimum allowed age
- License validity period
- License fees
- Class description

---

## 🧪 Tests Management

The system manages three main types of tests:

### 👁️ Vision Test
Records the test date and whether the applicant passed or failed.

### 📝 Written Test
Records the applicant's result and score out of 100.

### 🚘 Practical Driving Test
Records the result of the practical driving examination.

Applicants who fail a test can schedule another appointment and retake it after paying the required fees.

---

## 👤 People Management

The system allows employees to:

- Add new people.
- Search by National ID.
- View personal information.
- Edit personal information.
- Delete people.
- Prevent duplicate National IDs.

Personal information includes:

- National ID
- Full Name
- Date of Birth
- Address
- Phone Number
- Email
- Nationality
- Personal Photo

---

## 👨‍💼 Users Management

The system provides user administration features including:

- Add users.
- View users.
- Edit users.
- Delete users.
- Freeze user accounts.
- Manage user permissions.
- Link users to people in the system.

All system operations record the user who performed the action and the date of the operation.

---

## 📋 Applications Management

Applications can be searched and managed using:

- Application ID
- Applicant's National ID
- Application status

The system tracks:

- Application date
- Applicant
- Application type
- Application status
- Paid fees
- Related license class when applicable

---

## 🔐 License Management

The system keeps complete information about issued licenses, including:

- License ID
- Driver information
- National ID
- License class
- Issue date
- Expiration date
- License notes
- License status

The system also maintains the history of previously issued licenses.

---

## 🔎 License & Driver Inquiry

Employees can search for:

- A person's licenses using their National ID.
- A license using its license number.

Once a person receives their first driving license, they become a registered driver in the system and future licenses are linked to the same driver.

---

## 🗃️ System Administration

The system allows administrators to manage configurable system data, including:

- Application types and fees.
- Test fees.
- Driving license classes.
- Minimum ages.
- License validity periods.
- License fees.

---

## 🔄 General Workflow

```text
Applicant
   │
   ▼
Create Application
   │
   ▼
Select License Class
   │
   ▼
Vision Test
   │
   ▼
Written Test
   │
   ▼
Practical Driving Test
   │
   ▼
All Requirements Passed
   │
   ▼
Issue Driving License
```

---

## 🎯 Project Goals

The main goal of this project is to build a realistic system that demonstrates the management of a complete driving license workflow while applying concepts such as:

- Database design
- CRUD operations
- Business rules
- Validation
- User management
- Permissions
- Application workflows
- License lifecycle management
- Data integrity and relationships

---

## 📚 Project Source

This project is based on the **DVLD – Project 1: Driving License Management** requirements provided by ProgrammingAdvices.
