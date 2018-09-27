# Overview - Azure Redis Cache Strings
This code will help you to connect with an Azure Redis Cache Service and make operations with Redis using Strings through a .NET Application

# About the project

Redis is a dynamic database that storage in volatile memory. In this opportunity we can see how Redis works with strings.


# Technology used
* Visual Studio 2013.
* .NET (language C#).
* Microsoft Azure.

# Requirements

* Visual Studio 2015.
* Windows 7/8/10.
* One Microsoft Azure account.

# Comments

For run this code without errors, you must to create an Azure Redis Cache Service in Microsoft Azure, and get your own 
ConnectionString and passwords for the server.

Once you have your Azure Redis Cache service, now you need to set the property "SSL Port " no enabled if you don't do this action, you can't run the code correctly.
Don't forget to add the reference StackExchange.Redis from Nuget Package also.

[ API ]

If you want to know more about equivalences between Redis instructions and .NET instructions, you can see the following page: 
https://github.com/StackExchange/StackExchange.Redis/blob/master/StackExchange.Redis/StackExchange/Redis/IDatabase.cs
 
[ Monitor Tools ]
 
One tool that you can use for monitoring your redis data base is: Redis Desktop Manager from: http://redisdesktop.com

