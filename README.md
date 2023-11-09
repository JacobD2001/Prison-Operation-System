# Prison Operation System

> **Note**: This project is part of my learning journey and is one of my earlier projects. You can check out my more recent project on [GitHub](https://github.com/JacobD2001/HypeHaven).

Prison Operation System is a desktop application built with the use of the WPF (XAML) framework and C# in the .NET 6.0 framework. It is connected with a MySQL database, enabling users to manage a prison database. The application serves prison guards and management personnel.

## Login Panel
![Login Panel](https://user-images.githubusercontent.com/93675889/180433222-08e7a881-9825-47ba-9044-82128347646f.png)

Users are required to log in with usernames and passwords stored in the database. After successful login, the main window opens, providing access to multiple functionalities.

## Main Window
![Main Window](https://user-images.githubusercontent.com/93675889/180433350-bd517444-39f0-4a9e-a04d-be7ad1c5db85.png)
![Main Window 2](https://user-images.githubusercontent.com/93675889/180433450-8c089e5e-2ddc-411a-89f1-78ae755e7c24.png)
![Main Window 3](https://user-images.githubusercontent.com/93675889/180433601-946aaef6-9959-43fb-bfa7-ec068b68e499.png)

The main window allows users to access detailed prisoner information by entering the personal identity number (PESEL). Users can add or release prisoners, with the database being updated accordingly.

## Automatic Database Update
After adding or releasing a prisoner, the database is updated automatically. The window is refreshed, displaying the newly added prisoners in the drop-down list.

![Automatic Database Update](https://user-images.githubusercontent.com/93675889/180434502-2e3c218e-d5e7-4d6b-9d7e-0131329312e0.png)
![Automatic Database Update 2](https://user-images.githubusercontent.com/93675889/180434639-81b5aa41-cfbd-4d33-92db-1d960c9647ee.png)
![Automatic Database Update 3](https://user-images.githubusercontent.com/93675889/180434797-43d72dbc-7a9f-456a-8268-b8698fe9050b.png)

## Possible Ways of Further Development

-  Implement Unit Tests
-  Add an Installer for the Application
-  Migrate to Entity Framework for Enhanced Database Management
