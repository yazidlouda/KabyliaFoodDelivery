# KabyliaFoodDelivery


KabyliaFoodDelivery is an application for a person to Order their food online and get it delevred to his address--Think something similar to Doordash or grubhub. A User can go in and create a playlist, adding their favorite songs to it. A user can also see the songs on a particular Album, or Artists that have collaborated on a particular Album. A User's Playlist will show how many songs are on the playlist.

#How To Use This API
This API is run in Visual Studio. To run this application, please clone the master and run it on Visual Studio 2019 version 4.8 or higher. When you use the API, please start by creating a Username and a Password. The password must be at least 6 characters long, must have an uppercase letter, and a special character in it. Once you have done so, a token will be given to you. The token should then be used when creating/reading/updating/deleting any other infomation in this application.

There are a few caveats with this API:
There are a few foreign key relationships in this table, and this causes a couple of issues with how data is input. Since albums are connected to artists as well as songs, and album needs to be created first. Please see the endpoints/documentation below for more information. Next, a User needs to be created. After that, a song and artist can be created with the correct information. Lastly, a playlist can be created-- but in order to put information in the playlist, you must use the PlaylistSong joining table/endpoints.

Purpose of this API
The purpose of this API is to store songs for a user. For example, a user would be albe to find songs that he/she/they like and would be able to add the songs to a playlist. This would store songs for the User to listen to at a later date.
A more practical purpose of this API was for our team to learn how to use Team Github as well as understanding AGILE methodologies more fully. We used Trello (a planning application) to help us with our ticketing and divying up work.

Technologies
Net Framework C#
PostMan
Trello
GoogleDocs\

Launch
Visual Studio Community 2019 Version 16.7.5
Microsoft .Net Framework Version 4.8.04084\

How to use the
Data Structure
