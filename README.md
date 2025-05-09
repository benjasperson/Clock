# Clock
This is a simple clock app used to demonstrate issues that occur when updating the UI from timer thread while the UWP app is running in Kiosk mode (Assigned Access).


This can be compiled fore sidelaoding using Visual Studio 2022.  Once the solution
has been published and the .msixbundle file created, the package should be installed
for a user that will run in kiosk mode (Assigned Access). 

Assigned access can be set using the Powershell command Set-AssignedAccess

https://learn.microsoft.com/en-us/powershell/module/assignedaccess/set-assignedaccess?view=windowsserver2025-ps
