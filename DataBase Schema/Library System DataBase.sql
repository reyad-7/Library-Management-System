-- Create Database
CREATE DATABASE Library_Management_System;
GO

-- Switch to the newly created database
USE Library_Management_System;
GO

-- Create Members Table
CREATE TABLE Members(
    MemberID INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(40) NOT NULL,
    Email VARCHAR(50),
    Address VARCHAR(50)
);

Alter table Returns 
Alter column  Return_Date  DATE   not null

GO

-- Create Books Table
CREATE TABLE Books(
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(40) NOT NULL,
    Author VARCHAR(50),
    Genre VARCHAR(50),
    No_Of_Copies INT
);


GO

-- Create Checkouts Table
CREATE TABLE Checkouts(
    CheckOutID INT PRIMARY KEY IDENTITY(1,1),
    MemberID INT FOREIGN KEY REFERENCES Members(MemberID), 
    BookID INT FOREIGN KEY REFERENCES Books(BookID), 
    CheckOut_Date DATE NOT NULL,
    Due_Date DATE NOT NULL,
    Returned BIT NOT NULL
);
GO

-- Create Returns Table
CREATE TABLE Returns(
    ReturnID INT PRIMARY KEY IDENTITY(1,1),
    CheckOutID INT FOREIGN KEY REFERENCES Checkouts(CheckOutID), 
    Return_Date DATE NOT NULL
);
GO

-- Create Penalties Table
CREATE TABLE Penalties(
    PenaltyID INT PRIMARY KEY IDENTITY(1,1),
    CheckOutID INT FOREIGN KEY REFERENCES Checkouts(CheckOutID),
    Penalty_Amount INT,
    Paid_Status BIT NOT NULL
);

GO


Alter table Returns 
Alter column  Return_Date  DATE   not null

CREATE TABLE [Logins] (
    LoginID INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(100) UNIQUE NOT NULL,
    [Password] VARCHAR(100) NOT NULL,
	memberID int foreign key REFERENCES Members(MemberID) 
);

CREATE INDEX idx_email ON [Logins](Email);

