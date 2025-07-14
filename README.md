Teamified Local Event Planner & RSVP Tracker Backend

This Application is created in .Net Core using visual studio 2022 IDE , Followed a Clean architecture with repository pattern and used sqlite as database. Have simple Unit test to test the services.
Runs on : https://localhost:7038/api


<strong> Clean Architecture  : </strong> Divided the application into 4 main concepts API,Application,Core and Infrastructure
<ul>
  <li><strong>API : </strong> Entry point of the application, Configured CORS policy middleware here in order for the frontend to access the endpoints.</li>
  <li><strong>Application : </strong> This layer will handle the business logic.Services are stored here that is being called by the controller, Services has their own Interfaces to implement Dependency Injection and promote a loosely 
  coupled code. Dtos are also stored here to avoid too much data exposure.Extension methods are also created to help with formatting time and converting dtos to model and vice versa. </li>
  <li><strong>Core : </strong> This layer holds the database entities blueprints that will be created in the Database(Sqlite). Interfaces of the Repositories also stored here. </li>
  <li><strong>Infrastructure : </strong> Data migrations,database operations and DbContext are stored here. Project uses Entity Framework code first approach to create the schema of the database and also to perform CRUD operations.</li>
  <li><strong>Test : </strong> Unit test for services.</li>
</ul>
     


<pre>Auth Controller
        Has only 1 enpoint "login" , only returns the supplied username just to simulate doing API call upon login on UI.
  
     Event Controller
        Implemented constructor injection for the required service

     <strong>[HttpGet("GetEvents")] -  GetEvents(int size, int page)</strong>
         <i>Getting all events that is not in the past. Pagination ready but still not implemented on frontend</i>
     <strong>[HttpGet("GetEventsByUserAsync/{user}")] -GetEventByUserAsync([FromRoute] string user,int size, int page)</strong>
         <i>Getting all events that is not in the past filtered by username. Pagination ready but still not implemented on frontend</i>
     
