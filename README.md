# SQL-Server-Gerador-de-DACPAC
Este app é utilizado para exportar o código de uma base em formato DACPAC para que possa ser comparado usando Visual Studio ou Team Foundation

This app export the Database code into a DACPAC file to schema compare on Visual Studio or Team Foundation.

This app use Visual Studio 2015

2015-12-11 Version 1
Release 1

2016-06-14 Version 1.5
This Version I add a box to run 1x1 DACPAC or multiple at same time
I add a box to add the object permission on the extraction


????-??-?? Version X
I´m working on add a XML to translation, today the add already use a XML to save the last location of the SqlPackage.exe

BUG´s that I already know:
If you double click on the textbox to locate SqlPackage.exe and don´t select the file, or select other file, he accept this other file or bring the textbox with "", I´m working on that.
