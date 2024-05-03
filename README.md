# My Doggy Details
### This is a small fun application written in .Net MAUI left opensource for employers to review.
#### In practice it is an application to keep track of your pet dog's age and details.  Future features will allow sharing of details comprehensively, find dog parks and dog friendly locations, find vets, create "Lost Dog Alerts", find dog-sitters and other relevant services in "your" area.

Development started casually in March 2024.
So far, on the client side it uses these components:
+ Visual Studio 2022
+ C# 12 (many of it's latest coding features)
+ .Net Core 8.0
+ CommunityToolkit.Maui 3.0
+ ImageCropper.Maui 1.1.0.7
+ Maps
+ Camera
+ File System
+ Dapper 2.0.1
+ sql-net-pcl 1.8
+ MVVM design pattern.
+ XAML.
+ Binding.
+ Dependency Injection.
+ Interfaces (correct purposeful use of).
+ Async Task based programming.
+ SQLITE database used as local datastore.
+ Normalized database design.
+ Entity Framework Code First style creation of Sqlite database using light weight Dapper.
+ Release of the application to the Google Play and Apple stores.
+ Conditional compilation.

A planned web site application will follow in due course consisting of 
+ Angular 
+ C# API and backend. 
+ SQL SERVER database


My [LinkedIn Profile](https://www.linkedin.com/in/raymond-b-76779866/) 

Note: You will require your own API Keys to make this application work and interact with online components and services.
Note: Certain files will not be updated to protect developer's keys etc.
Note: This is not the finished application, mearly a sample demonstration of skills and competency.



APRIL 2022
Added Connected to The Dog API to download infos and pictures - needs to be paged(if possible and made async).
Created a picture Downsize function to create icons.
Dogs from The Dog API are saved locally but are very slow - needs to be paged and made async


Thanks to "jbowmanp1107 Jeff" for ImageCropper
https://github.com/jbowmanp1107/ImageCropper.Maui?tab=readme-ov-file#readme
